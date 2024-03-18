using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using WBAuth.Back.JwtFeatures;
using WBAuth.BLL.Manager;
using Microsoft.AspNetCore.WebUtilities;
using WBAuth.DAL.Models;
using Google.Apis.Auth;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;


namespace WBAuth.Back.Controllers
{
    [Route("api/[controller]")]
    //[Authorize] 
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly IUtilisateurManager _UtilisateurManager;
        private UserManager<DAL.Models.Utilisateur> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationSettings _applicationSettings;
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _dataContext;

        public UtilisateurController(UserManager<DAL.Models.Utilisateur> userManager, IUtilisateurManager UtilisateurManager
              ,IMapper mapper ,JwtHandler jwtHandler ,IEmailSender emailSender ,ApplicationDbContext dataContext
              ,IOptions<ApplicationSettings> _applicationSettings, HttpClient httpClient )
        { 
            _UtilisateurManager = UtilisateurManager;  
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _emailSender = emailSender;
            this._applicationSettings = _applicationSettings.Value;
            _httpClient = httpClient;
            _dataContext = dataContext;
        }


        private async Task<IActionResult> GenerateOTPFor2StepVerification(DAL.Models.Utilisateur user)
        {
            var providers = await _userManager.GetValidTwoFactorProvidersAsync(user);
            if (!providers.Contains("Email"))  return Unauthorized(new AuthResponse { ErrorMessage = "Invalid 2-Step Verification Provider." });         
            var token2FA = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            var message = new Message(new string[] { user.Email }, "Verifier votre identifiant", token2FA, null);
            await _emailSender.SendEmailAsync(message ,"verificationDoubleFacteur");
            return Ok(new AuthResponse { Is2StepVerificationRequired = true, Provider = "Email" });
        }
        
        
        [HttpPost("TwoStepVerification")]
        public async Task<IActionResult> TwoStepVerification([FromBody] TwoFactorDto twoFactorDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.FindByEmailAsync(twoFactorDto.Email);
            if (user is null) return BadRequest(new AuthResponse { ErrorMessage = "Requete echouée !" });
            var validVerification = await _userManager.VerifyTwoFactorTokenAsync(user, twoFactorDto.Provider, twoFactorDto.Code);
            if (!validVerification) return BadRequest(new AuthResponse { ErrorMessage = "Verification du code échouée !" });

            var token = _jwtHandler.GenerateToken(user);
            return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login Login)
        {
            var user = await _userManager.FindByNameAsync(Login.UserName);
            if (user == null) user = await _userManager.FindByEmailAsync(Login.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, Login.Password))
              return Unauthorized(new AuthResponse { ErrorMessage = "Veuillez saisir le nom d'utilisateur/email et le mot de passe correctement !" });
            if (!await _userManager.IsEmailConfirmedAsync(user))
              return Unauthorized(new AuthResponse { ErrorMessage = "Veuillez confirmer votre inscription par email !" });
            if (await _userManager.GetTwoFactorEnabledAsync(user)) return await GenerateOTPFor2StepVerification(user);
            var token = _jwtHandler.GenerateToken(user);
            return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
        }


        [HttpPost("LoginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] string credential)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()  { Audience = new List<string> { this._applicationSettings.GoogleClientId }   };
            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);
            var fullname = payload.GivenName.ToLower() + payload.FamilyName.ToLower();
            var users = await _dataContext.Set<DAL.Models.Utilisateur>().ToListAsync();
    
            var user = users.FirstOrDefault(x => ( x.Prenom.ToLower() + x.Nom.ToLower() ) == fullname);
            if (user == null) return NotFound($"l'utilisateur avec le nom et le prénom \"{payload.GivenName.ToLower() + " " + payload.FamilyName.ToLower()}\" est introuvable.");

            var token = _jwtHandler.GenerateToken(user);
            if (user != null){ return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token ,Payload = payload ,username = user.UserName}); }
            else{   return BadRequest();   }
        }


        [HttpPost("LoginWithFacebook")]
        public async Task<IActionResult> LoginWithFacebook([FromBody] string credential)
        {
            HttpResponseMessage debugTokenResponse = await _httpClient.GetAsync("https://graph.facebook.com/debug_token?input_token=" + credential + $"&access_token={this._applicationSettings.FacebookAppId}|{this._applicationSettings.FacebookSecret}");
            var stringThing = await debugTokenResponse.Content.ReadAsStringAsync();
            var userOBJK = JsonConvert.DeserializeObject<FBUser>(stringThing);
            if(userOBJK == null) return NotFound(userOBJK);
            if (userOBJK.Data.IsValid == false) { return Unauthorized(); }

            HttpResponseMessage meResponse = await _httpClient.GetAsync("https://graph.facebook.com/me?fields=first_name,last_name,email,id&access_token=" + credential);
            var userContent = await meResponse.Content.ReadAsStringAsync();
            var userContentObj = JsonConvert.DeserializeObject<FBUserInfo>(userContent);
            if (userContentObj == null) return NotFound(userContentObj);

            var users = await _dataContext.Set<DAL.Models.Utilisateur>().ToListAsync();
            var fullname = userContentObj.FirstName.ToLower() + userContentObj.LastName.ToLower();
            var user = users.FirstOrDefault(x => (x.Prenom.ToLower() + x.Nom.ToLower()) == fullname);
            if (user == null) return NotFound($"l'utilisateur avec le nom et le prénom \"{userContentObj.FirstName.ToLower() + " " + userContentObj.LastName.ToLower()}\" est introuvable.");

            var token = _jwtHandler.GenerateToken(user);
            if (user != null) { return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token, Payload = userContentObj, username = user.UserName  }); }
            else { return BadRequest(); }
        }


        [HttpPost("LoginWithLinkedIn")]
        public async Task<IActionResult> LoginWithLinkedIn([FromBody] string credential)
        {
            var TokenUri = "https://www.linkedin.com/oauth/v2/accessToken";
            var redirectUri = "https://localhost:44429/LinkedIn";
            var tokenParameters = new Dictionary<string, string>
            { { "grant_type", "authorization_code" },{ "code", credential }, { "client_id", "86pe6918u7eg1h" },
              { "client_secret", "Gpg4qLShgX0xVNim" } ,{ "redirect_uri", redirectUri } };

            var tokenEncodedContent = new FormUrlEncodedContent(tokenParameters);
            tokenEncodedContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
            HttpResponseMessage tokenResponse = await _httpClient.PostAsync(TokenUri, tokenEncodedContent);
            if (!tokenResponse.IsSuccessStatusCode){   return StatusCode((int)tokenResponse.StatusCode);  }
            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            if (tokenContent == null) throw new Exception("tokenContent est null !");
            var tokenInfo = JsonConvert.DeserializeObject<LinkedInToken>(tokenContent);
            if (tokenInfo == null) throw new Exception("tokenContent est null !");
            
            var userInfoUri = "https://api.linkedin.com/v2/userinfo";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenInfo.accessToken);
            HttpResponseMessage userInfoResponse = await _httpClient.GetAsync(userInfoUri);
            if (!userInfoResponse.IsSuccessStatusCode) { return StatusCode((int)userInfoResponse.StatusCode); }
            var userInfoContent = await userInfoResponse.Content.ReadAsStringAsync();
            if (userInfoContent == null) throw new Exception("userInfoContent est null !");
            var userInfo = JsonConvert.DeserializeObject<LinkedInUserInfo>(userInfoContent);
            if (userInfo == null) throw new Exception("userInfo est null !");

            var users = await _dataContext.Set<DAL.Models.Utilisateur>().ToListAsync();
            var fullname = userInfo.firstName.ToLower() + userInfo.lastName.ToLower();
            var user = users.FirstOrDefault(x => (x.Prenom.ToLower() + x.Nom.ToLower()) == fullname);

            var token = _jwtHandler.GenerateToken(user);
            if (user != null) { return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token, Payload = userInfo, username = user.UserName }); }
            else { return BadRequest(); }
        }


        //POST : api/Utilisateur/inscription
        [HttpPost]
        [Route("inscription")]
        public async Task<IActionResult> Inscription([FromBody] BO.Utilisateur oUser)
        {
            if (oUser == null) throw new ArgumentNullException(nameof(oUser));
            if (ModelState.IsValid)
            {
                var oUtilisateur = _mapper.Map<DAL.Models.Utilisateur>(oUser);
                Guid GuidUser = Guid.NewGuid();
                oUtilisateur.Id = GuidUser.ToString();
                var ClientURI = "https://localhost:44429/EmailConfirmation";
                var res = await _userManager.CreateAsync(oUtilisateur, oUser.Password);
                if (!res.Succeeded)
                {
                    var errors = res.Errors.Select(error => new { code = error.Code, description = error.Description });
                    return BadRequest(new { succeeded = false, errors });
                }

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(oUtilisateur);
                var param = new Dictionary<string, string?>{ {"token", token }, {"email", oUtilisateur.Email } };
                var callback = QueryHelpers.AddQueryString(ClientURI, param);
                var message = new Message(new string[] { oUtilisateur.Email }, "Confirmer votre inscription", callback, null);
                await _emailSender.SendEmailAsync(message,"emailConfirmation");
                return StatusCode(201); 
            }
            else return BadRequest(ModelState); 
        }



        [HttpGet("emailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest("Requete de confirmation email invalide");
            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded) return BadRequest("Requete de confirmation email invalide");
            return Ok();
        }


        //POST : api/Utilisateur/resetPassword
        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
            if (user == null) return BadRequest("Email Inexistant");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string?>

        {   {"token", token }, {"email", forgotPasswordDto.Email }  };
            if (forgotPasswordDto.ClientURI == null) throw new Exception("ClientURI est null");
            var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
            var message = new Message(new string[] { user.Email }, "Reinitialisation du mot de passe", callback ,null);
            await _emailSender.SendEmailAsync(message ,"réinitialisation");
            return Ok();
        }


        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)  return BadRequest();
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)  return BadRequest("Invalid Request");

            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }
            return Ok();
        }


        [HttpGet]
        [Route("checkPassword/{email}/{passwordToCheck}")]
        public async Task<IActionResult> checkPassword(string email ,string passwordToCheck)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user == null){  return NotFound("Utilisateur non trouvé");  }
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, passwordToCheck);
            if (isPasswordCorrect){  return Ok(isPasswordCorrect);  }
            else{  return BadRequest(!isPasswordCorrect);  }
        }
    



    /************************************************************ CRUD *********************************************************/
    //GET : api/Utilisateur/List
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> ChargerAll()
        {
            var oUtilisateur = await _UtilisateurManager.ChargerAll();
            if (oUtilisateur == null)  return NoContent();
            return Ok(oUtilisateur);
        }


        //GET : api/Utilisateur/idUtilisateur
        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<IActionResult> RechercheById(string Id)
        {
            var oUtilisateur = await _UtilisateurManager.RechercheById(Id);
            if (oUtilisateur == null)  return NoContent();
            return Ok(oUtilisateur);
        }


        //GET : api/Utilisateur/idUtilisateur
        [HttpGet]
        [Route("Recherche/{rech}")]
        public async Task<IActionResult> Recherche(string rech)
        {
            var oUtilisateur = await _UtilisateurManager.Recherche(rech);
            if (oUtilisateur == null) return NoContent();
            return Ok(oUtilisateur);
        }



        //PUT : api/Utilisateur/modifier
        [HttpPut]
        [Route("modifier/{Id}")]
        public async Task<IActionResult> Modifier([FromBody] WBAuth.BO.Utilisateur oUser ,string Id)
        {
            if (oUser== null) throw new ArgumentNullException(nameof(oUser));
            if (ModelState.IsValid)
            {
                var oUtilisateur = _mapper.Map<DAL.Models.Utilisateur>(oUser);
                var entity = await _userManager.FindByIdAsync(Id);
                if (entity == null) return NotFound($"Utilisateur avec l'ID {Id} introuvable.");
                entity.UserName = oUtilisateur.UserName;
                entity.Email = oUtilisateur.Email;
                entity.Status = oUtilisateur.Status;
                entity.Nom = oUtilisateur.Nom;
                entity.Prenom = oUtilisateur.Prenom;
                entity.TwoFactorEnabled = oUtilisateur.TwoFactorEnabled;
                var result = await _userManager.UpdateAsync(entity);
                if (result.Succeeded){   return Ok(entity);  }
                else
                {
                    var errors = result.Errors.Select(error => new { code = error.Code, description = error.Description });
                    return BadRequest(new { succeeded = false, errors });
                }
            }
            else{   return BadRequest(ModelState);  }
        }



        //DELETE : api/Utilisateur/supprimer/{Id}
        [HttpDelete]
        [Route("supprimer/{Id}")]
        public async Task<IActionResult> Supprimer(string Id)
        {
            var userToDelete = await _userManager.FindByIdAsync(Id);
            if (userToDelete == null) return NotFound($"Utilisateur avec l'ID {Id} introuvable.");
            var result = await _userManager.DeleteAsync(userToDelete);
            if (result.Succeeded) return Ok(new { message = "Utilisateur supprimé avec succès" });
            else
            {
                var errors = result.Errors.Select(error => new { code = error.Code, description = error.Description });
                return BadRequest(new { succeeded = false, errors });
            }
        }




    }
}


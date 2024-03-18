using WBAuth.BLL.IManager;
using WBAuth.BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using WBAuth.Back.JwtFeatures;
using WBAuth.BLL.Manager;
using Microsoft.AspNetCore.WebUtilities;
using WBAuth.DAL.Models;
using WBAuth.DAL.Repository;
using Google.Apis.Auth;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace WBAuth.Back.Controllers
{
    [Route("api/[controller]")]
    //[Authorize] 
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IUtilisateurManager _UtilisateurManager;
        private UserManager<DAL.Models.Utilisateur> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtHandler _jwtHandler;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationSettings _applicationSettings;
        private readonly HttpClient _httpClient;
        private readonly ApplicationDbContext _dataContext;
        private readonly IApplicationManager _applicationManager;
        private readonly IUtilisateurApplicationManager _uaManager;
        private readonly IRoleManager _roleManager;
        private readonly IActionManager _actionManager;
        private readonly IJournalisationManager _journalisationManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IFonctionManager _fonctionManager;


        public ServiceController(UserManager<DAL.Models.Utilisateur> userManager, IUtilisateurManager UtilisateurManager
              ,IMapper mapper ,JwtHandler jwtHandler ,IEmailSender emailSender ,IApplicationManager applicationManager
              ,IOptions<ApplicationSettings> _applicationSettings, HttpClient httpClient ,ApplicationDbContext dataContext
              ,IUtilisateurApplicationManager uaManager ,IRoleManager roleManager ,IActionManager actionManager
              ,IJournalisationManager journalisationManager ,IFonctionManager fonctionManager 
              ,IPermissionManager permissionManager)
        { 
            _UtilisateurManager = UtilisateurManager;  
            _userManager = userManager;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
            _emailSender = emailSender;
            this._applicationSettings = _applicationSettings.Value;
            _httpClient = httpClient;
            _dataContext = dataContext;
            _applicationManager = applicationManager;
            _uaManager = uaManager;
            _roleManager = roleManager;
            _actionManager = actionManager;
            _journalisationManager = journalisationManager;
            _permissionManager = permissionManager;
            _fonctionManager = fonctionManager;
        }


        [HttpGet("RemoveURLPrefixes")]
        public string RemoveURLPrefixes(string url)
        {
            url = Uri.UnescapeDataString(url);
            string[] prefixes = { "http://", "https://", "http:/" ,"https:/" };
            foreach (var prefix in prefixes) { if (url.StartsWith(prefix)) { url = url.Substring(prefix.Length); } }
            if (url.EndsWith("/")) {  url = url.Substring(0, url.Length - 1);  }
            return url; 
        }



        [HttpGet]
        [Route("redirectConnexion/{urlApplication}")]
        public async Task<string> RedirectConnexion(string urlApplication)
        {
            string url = RemoveURLPrefixes(urlApplication);
            var app = await _dataContext.Set<DAL.Models.Application>().Where(a => a.Url == url).ToListAsync();
            if (app.Count == 0 || string.IsNullOrEmpty(urlApplication)) return "URL invalide !";
            string loginUrl = "https://localhost:44429/";
            if (!string.IsNullOrEmpty(urlApplication)) { loginUrl += "AuthentificationAppExterne/" + url;  }
            loginUrl = Uri.UnescapeDataString(loginUrl);
            return loginUrl;
        }


        [HttpGet]
        [Route("redirectInscription/{urlApplication}")]
        public async Task<string> RedirectInscription(string urlApplication)
        {
            string url = RemoveURLPrefixes(urlApplication);
            var app = await _dataContext.Set<DAL.Models.Application>().Where(a => a.Url == url).ToListAsync();
            if (app.Count == 0 || string.IsNullOrEmpty(urlApplication)) return "URL invalide !";
            string loginUrl = "https://localhost:44429/";
            if (!string.IsNullOrEmpty(urlApplication)) { loginUrl += "InscriptionAppExterne/" + url; }
            loginUrl = Uri.UnescapeDataString(loginUrl);
            return loginUrl;
        }


        [HttpGet]
        [Route("redirectConnexionReussi/{urlApplication}/{token}")]
        public async Task<IActionResult> RedirectConnexionReussi(string urlApplication ,string token)
        {
            string url = RemoveURLPrefixes(urlApplication);
            var app = await _dataContext.Set<DAL.Models.Application>().Where(a => a.Url == url).ToListAsync();
            if (app.Count == 0 || string.IsNullOrEmpty(urlApplication)) return BadRequest("URL invalide !");
            if (string.IsNullOrEmpty(token)) return BadRequest("erreur de récuperation du token !");
            string requete = urlApplication + "/getToken";
            HttpResponseMessage response = await _httpClient.GetAsync(requete);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            else return BadRequest("Erreur lors de la requête vers " + urlApplication + "! Erreur : " + response.StatusCode);
        }


        private async Task<IActionResult> GenerateOTPFor2StepVerification(DAL.Models.Utilisateur user)
        {
            var providers = await _userManager.GetValidTwoFactorProvidersAsync(user);
            if (!providers.Contains("Email")) return Unauthorized(new AuthResponse { ErrorMessage = "Invalid 2-Step Verification Provider." });
            var token2FA = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            var message = new Message(new string[] { user.Email }, "Verifier votre identifiant", token2FA, null);
            await _emailSender.SendEmailAsync(message, "verificationDoubleFacteur");
            return Ok(new AuthResponse { Is2StepVerificationRequired = true, Provider = "Email" });
        }


        [HttpPost("TwoStepVerificationAppExterne")]
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


        [HttpPost("loginApplication/{urlApplication}")]
        public async Task<IActionResult> LoginApp([FromBody] Login login ,string urlApplication)
        {
            BO.Application app = new BO.Application();
            bool rech = false;
            var apps = await _applicationManager.Recherche(urlApplication);
            if (apps != null && apps.Any()) {  app = apps.First();  }
            else {  return BadRequest(new AuthResponse { ErrorMessage = "URL invalide !" });  }
            var userApps = await _uaManager.ChargerAllByApplication(app.Id);
            foreach (var ua in userApps)
            {
                var u = await _UtilisateurManager.RechercheById(ua.GuidUtilisateur);
                if (u.UserName == login.UserName || u.Email == login.UserName ){  rech = true;  }
            }
            if (rech){
                var user = await _userManager.FindByNameAsync(login.UserName);
                if (user == null) user = await _userManager.FindByEmailAsync(login.UserName);
                if (!await _userManager.CheckPasswordAsync(user, login.Password))
                    return Unauthorized(new AuthResponse { ErrorMessage = "Veuillez saisir le mot de passe correctement !" });
                if (!await _userManager.IsEmailConfirmedAsync(user))
                    return Unauthorized(new AuthResponse { ErrorMessage = "Veuillez confirmer votre inscription par email !" });
                if ((bool)user.Status == false) 
                    return Unauthorized(new AuthResponse { ErrorMessage = "Votre Compte est desactivé ,Veuillez contacter l'administrateur pour plus d'information !" });
                if (await _userManager.GetTwoFactorEnabledAsync(user) && app.Auth2FA == true) return await GenerateOTPFor2StepVerification(user);
                var token = _jwtHandler.GenerateToken(user);
                return Ok(new AuthResponse { IsAuthSuccessful = true, Token = token });
            }
            return BadRequest(new AuthResponse { ErrorMessage = "Veuillez saisir le nom d'utilisateur/email correctement !" });
        }




        [HttpPost]
        [Route("inscriptionApplication/{urlApplication}")]
        public async Task<IActionResult> InscriptionApplication([FromBody] BO.Utilisateur oUser, string urlApplication)
        {
            if (oUser == null) throw new ArgumentNullException(nameof(oUser));
            BO.Application app = new BO.Application();
            var apps = await _applicationManager.Recherche(urlApplication);
            if (apps != null && apps.Any()){  app = apps.First();  }
            else { return Unauthorized(new AuthResponse { ErrorMessage = "URL de l'application invalide !" }); }

            var usersApp = await _uaManager.ChargerAllByApplication(app.Id);
            foreach (var ua in usersApp)
            {
               var u = await _UtilisateurManager.RechercheById(ua.GuidUtilisateur);
               if (u.UserName == oUser.UserName) return Unauthorized(new AuthResponse { ErrorMessage = "Le nom d'utilisateur saisi est déjà utilisé !" }); 
               else if (u.Email == oUser.Email) return Unauthorized(new AuthResponse { ErrorMessage = "L'email saisi est déjà utilisé !" });
            }

            var users = await _dataContext.Set<DAL.Models.Utilisateur>().ToListAsync(); 
            var user = users.FirstOrDefault(u => u.UserName == oUser.UserName || u.Email == oUser.Email);
            if (user == null)
            {
                if (ModelState.IsValid)
                {
                    var oUtilisateur = _mapper.Map<DAL.Models.Utilisateur>(oUser);
                    Guid GuidUser = Guid.NewGuid();
                    oUser.Id = GuidUser.ToString();
                    oUtilisateur.Id = GuidUser.ToString();
                    var ClientURI = "https://localhost:44429/EmailConfirmation";
                    var res = await _userManager.CreateAsync(oUtilisateur, oUser.Password);

                    BO.UtilisateurApplication oUA = new BO.UtilisateurApplication();
                    oUA.GuidUtilisateur = oUser.Id;
                    oUA.Utilisateur = oUser;
                    oUA.IdApplication = app.Id;
                    oUA.Application = app;
                    oUA.Acces = true;
                    var idUA = await _uaManager.Ajouter(oUA);
                    if (idUA == null) return Unauthorized(new AuthResponse { ErrorMessage = "Erreur l'utilisateur n'est pas effectué à l'application !" });

                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(oUtilisateur);
                    var param = new Dictionary<string, string?> { { "token", token }, { "email", oUtilisateur.Email } };
                    var callback = QueryHelpers.AddQueryString(ClientURI, param);
                    var message = new Message(new string[] { oUtilisateur.Email }, "Confirmer votre inscription", callback, null);
                    await _emailSender.SendEmailAsync(message, "emailConfirmation");
                    return StatusCode(201);
                }
            }
            else if(user != null){
                BO.UtilisateurApplication oUA = new BO.UtilisateurApplication();
                var userBO = _mapper.Map<BO.Utilisateur>(user);
                oUA.GuidUtilisateur = user.Id;
                oUA.Utilisateur = userBO;
                oUA.IdApplication = app.Id;
                oUA.Application = app;
                oUA.Acces = true;
                var idUA = await _uaManager.Ajouter(oUA);
                if (idUA == null) return Unauthorized(new AuthResponse { ErrorMessage = "Erreur l'utilisateur n'est pas effectué à l'application !" });
                return StatusCode(201);
            }
            return BadRequest(ModelState);
        }








    }
}


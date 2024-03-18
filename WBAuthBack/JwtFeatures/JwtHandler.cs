using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WBAuth.DAL.Models;

namespace WBAuth.Back.JwtFeatures
{

    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly ApplicationSettings _applicationSettings;
        private readonly HttpClient _httpClient;

        public JwtHandler(IConfiguration configuration ,IOptions<ApplicationSettings> _applicationSettings, HttpClient httpClient)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JwtSettings");
            this._applicationSettings = _applicationSettings.Value;
            _httpClient = httpClient;
        }


        public string GenerateToken(Utilisateur user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }


        public List<Claim> GetClaims(Utilisateur user)
        {
            var claims = new List<Claim>
        {   new Claim(ClaimTypes.Name, user.Email)    };
            return claims;
        }


        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }





    }



}

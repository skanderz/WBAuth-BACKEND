using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using WBAuth.BO.Validators;

namespace WBAuth.BO
{
    public class Application
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        [JsonIgnore]
        [AllowedImageExtensions(".png", ".jpg", ".jpeg", ".gif", ".bmp")]
        public byte[]? Logo { get; set; }
        public bool Auth2FA { get; set; } = false;
        public bool AuthGoogle { get; set; } = false;
        public bool AuthFacebook { get; set; } = false;
        public bool AuthLinkedIn { get; set; } = false;


        [JsonIgnore]
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }

        [JsonIgnore]
        public ICollection<Fonction>? Fonctions { get; set; }

        [JsonIgnore]
        public ICollection<Role>? Roles { get; set; }

    }

}

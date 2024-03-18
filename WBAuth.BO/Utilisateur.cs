using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class Utilisateur 
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateInscription { get; set; }
        public bool? Status { get; set; }
        public bool? EmailConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        [JsonIgnore]
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        [JsonIgnore]
        public ICollection<Journalisation>? Journalisations { get; set; }
    }
}




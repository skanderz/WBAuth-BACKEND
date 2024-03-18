using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Utilisateur")]
    public class Utilisateur : IdentityUser
    {
        [Required]
        [Column("Nom", TypeName = "VARCHAR(MAX)")]
        public string? Nom { get; set; }

        [Required]
        [Column("Prenom", TypeName = "VARCHAR(MAX)")]
        public string? Prenom { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateInscription { get; set; } = new DateTime();
        public bool? Status { get; set; } = true;
        public ICollection<UtilisateurApplication>? UtilisateurApplications { get; set; }
        public ICollection<Journalisation>? Journalisations { get; set; }

    }
}

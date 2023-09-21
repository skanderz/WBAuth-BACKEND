using System.ComponentModel.DataAnnotations;

namespace WBAuth.BO
{
    public class Utilisateur
    {

        public int IdUtilisateur { get; set; }
        public string? NomUtilisateur { get; set; }
        public string? Email { get; set; }

        [Required]
        public string? MotDePasse { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateInscription { get; set; }
        public bool? Status { get; set; }
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        public ICollection<Journalisation>? Journalisation { get; set; }
    }
}




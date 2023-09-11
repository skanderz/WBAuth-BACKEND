using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;


namespace WBAuth.DAL.Models
{
    [Table("Utilisateur")]
    public class Utilisateur{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdUtilisateur")]
        public int IdUtilisateur { get; set; }


        [Required]
        [Column("NomUtilisateur", TypeName = "VARCHAR(50)")]
        public string? NomUtilisateur { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        [Column("EMAIL", TypeName = "VARCHAR(100)")]
        public string? Email { get; set; }


        [Required]
        [Column("MotDePasse", TypeName = "TEXT")]
        public string? MotDePasse { get; set; }


        [Required]
        [Column("Nom", TypeName = "VARCHAR(50)")]
        public string? Nom { get; set; }


        [Required]
        [Column("Prenom", TypeName = "VARCHAR(50)")]
        public string? Prenom { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime? DateInscription { get; set; }
        public bool? Status { get; set; } = true;
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        public ICollection<Journalisation>? Journalisation { get; set; }

    }
}

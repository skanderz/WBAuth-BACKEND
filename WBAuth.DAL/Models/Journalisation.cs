using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Journalisation")]
    public class Journalisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Application", TypeName = "TEXT")]
        public string? Application { get; set; }

        [Column("AdresseIP", TypeName = "VARCHAR(MAX)")]
        public string? AdresseIP { get; set; }

        [Column("DateConnexion", TypeName = "datetime")]
        public DateTime DateConnexion { get; set; }

        [ForeignKey("Utilisateur")]
        public string? GuidUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public ICollection<Action>? Actions { get; set; }

    }
}



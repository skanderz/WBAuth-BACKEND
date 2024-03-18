using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WBAuth.DAL.Models
{
    [Table("UtilisateurApplication")]
    public class UtilisateurApplication
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Role, DeleteBehavior = DeleteBehavior.NoAction")]
        public int? IdRole { get; set; }

        [InverseProperty("UtilisateurApplications")]
        public Role? Role { get; set; }


        [ForeignKey("Utilisateur, DeleteBehavior = DeleteBehavior.Cascade")]
        [Required]
        public string? GuidUtilisateur { get; set; }
        [InverseProperty("UtilisateurApplications")]
        public Utilisateur? Utilisateur { get; set; }


        [ForeignKey("Application, DeleteBehavior = DeleteBehavior.Cascade")]
        [Required]
        public int IdApplication { get; set; }

        [InverseProperty("UtilisateurApplications")]
        public Application? Application { get; set; }


        [Required]
        public bool Acces { get; set; } = true;


    }
}

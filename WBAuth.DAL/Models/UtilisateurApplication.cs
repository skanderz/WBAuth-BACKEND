using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WBAuth.DAL.Models
{
    [Table("UtilisateurApplication")]
    public class UtilisateurApplication
    {


        [Key]
        public int Id { get; set; }

        [ForeignKey("Role, DeleteBehavior = DeleteBehavior.NoAction")]
        public int IdRole { get; set; }
        [Required]
        [InverseProperty("UtilisateurApplication")]
        public Role? Role { get; set; }


        [ForeignKey("Utilisateur, DeleteBehavior = DeleteBehavior.NoAction")]
        public int IdUtilisateur { get; set; }
        [Required]
        [InverseProperty("UtilisateurApplication")]
        public Utilisateur? Utilisateur { get; set; }


        [ForeignKey("Application, DeleteBehavior = DeleteBehavior.NoAction")]
        public int IdApplication { get; set; }
        [Required]
        [InverseProperty("UtilisateurApplication")]
        public Application? Application { get; set; }



        [Required]
        public bool Acces { get; set; } = true;


    }
}

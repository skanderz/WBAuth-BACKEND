using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Permission")]
    public class Permission{
        [Key]
        public int Id { get; set; }


        [ForeignKey("Role, DeleteBehavior = DeleteBehavior.NoAction")]
        public int IdRole { get; set; }
        [Required]
        [InverseProperty("Permission")]
        public Role? Role { get; set; }


        [ForeignKey("Fonction, DeleteBehavior = DeleteBehavior.NoAction")]
        public int IdFonction { get; set; }
        [Required]
        [InverseProperty("Permission")]
        public Fonction? Fonction { get; set; }


        [Required]
        public string? Nom { get; set; }

        public string Status { get; set; } = "111111";


    }
}



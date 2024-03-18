using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Role")]
        public int IdRole { get; set; }
        [Required]
        [InverseProperty("Permissions")]
        public Role? Role { get; set; }


        [ForeignKey("Fonction")]
        public int IdFonction { get; set; }
        [Required]
        [InverseProperty("Permissions")]
        public Fonction? Fonction { get; set; }


        [Required]
        public string? Nom { get; set; }

        public string Status { get; set; } = "111111";


    }
}



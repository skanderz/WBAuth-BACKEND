using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Permission")]
    public class Permission{
        [Key]
        [ForeignKey("Role")]
        public int IdRole { get; set; }

        [Required]
        [InverseProperty("Permission")]
        public Role? Role { get; set; }



        [Key] 
        [ForeignKey("Fonction")]
        public int IdFonction { get; set; }

        [Required]
        [InverseProperty("Permission")]
        public Fonction? Fonction { get; set; }


        [Required]
        public bool Status { get; set; } = true;

    }
}



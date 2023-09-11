using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models
{
    [Table("Role")]
    public class Role{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdRole")]
        public int IdRole { get; set; }


        [Required]
        [Column("Nom", TypeName = "VARCHAR(50)")]
        public string? Nom { get; set; }


        public int? Niveau { get; set; }



        [Column("Nom", TypeName = "TEXT")]
        public string? Description { get; set; }


        public Permission? Permission { get; set; }
        public UtilisateurApplication? UtilisateurApplication { get; set; }



        [ForeignKey("Application")]
        public int IdApplication { get; set; }
        public Application? Application { get; set; }


    }


}

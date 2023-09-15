using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace WBAuth.DAL.Models
{
    [Table("UtilisateurApplication")]
    public class UtilisateurApplication{


        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }
        [Required]
        [InverseProperty("UtilisateurApplication")]
        public Role? Role { get; set; }


        [ForeignKey("Utilisateur")]
        public int IdUtilisateur { get; set; }
        [Required]
        [InverseProperty("UtilisateurApplication")]
        public Utilisateur? Utilisateur { get; set; }


        [ForeignKey("Application")]
        public int IdApplication { get; set; }
        [Required]
        [InverseProperty("UtilisateurApplication")]
        public Application? Application { get; set; }



        [Required]
        public bool Acces { get; set; } = true;


    }
}

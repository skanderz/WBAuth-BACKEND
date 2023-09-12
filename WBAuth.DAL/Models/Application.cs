﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WBAuth.DAL.Models{
    [Table("Application")]
    public class Application{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        [Column("Nom", TypeName = "VARCHAR(50)")]
        public string? Nom { get; set; }



        [Column("Description", TypeName = "TEXT")]
        public string? Description { get; set; }



        [Column("Url", TypeName = "VARCHAR(50)")]
        public string? Url { get; set; }



        [Column("Logo", TypeName = "varbinary(max)")]
        public byte[]? Logo { get; set; }


        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        public ICollection<Fonction>? Fonctions { get; set; }
        public ICollection<Role>? Role { get; set; }



    }

}
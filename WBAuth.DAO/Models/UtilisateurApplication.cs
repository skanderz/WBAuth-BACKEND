using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace WBAuth.DAO.Models
{
    public class UtilisateurApplication{

        public int IdRole { get; set; }
        public Role? Role { get; set; }
        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public int IdApplication { get; set; }
        public Application? Application { get; set; }
        public bool Acces { get; set; } = true;


    }
}

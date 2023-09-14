using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Models
{
    public class Utilisateur{

        public int IdUtilisateur { get; set; }
        public string? NomUtilisateur { get; set; }
        public string? Email { get; set; }

        [Required]
        public string? MotDePasse { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateInscription { get; set; }
        public bool? Status { get; set; }
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        public ICollection<Journalisation>? Journalisation { get; set; }
    }
}




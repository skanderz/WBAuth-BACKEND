using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Models
{
    public class Application{

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public byte[]? Logo { get; set; }
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        public ICollection<Fonction>? Fonctions { get; set; }
        public ICollection<Role>? Role { get; set; }

    }

}

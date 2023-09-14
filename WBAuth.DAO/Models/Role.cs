using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Models
{
    public class Role{

        public int IdRole { get; set; }
        public string? Nom { get; set; }
        public int? Niveau { get; set; }
        public string? Description { get; set; }
        public Permission? Permission { get; set; }
        public UtilisateurApplication? UtilisateurApplication { get; set; }
        public int IdApplication { get; set; }
        public Application? Application { get; set; }

    }


}


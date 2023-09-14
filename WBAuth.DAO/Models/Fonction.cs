using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Models
{
    public class Fonction{
        public int IdFonction { get; set; }
        public string? Nom { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public Permission? Permission { get; set; }
        public int IdApplication { get; set; }
        public Application? Application { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Models
{
    public class Journalisation{

        public int IdJournalisation { get; set; }
        public string? AdresseIP { get; set; }
        public DateTime DateConnexion { get; set; }
        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public ICollection<Action>? Actions { get; set; }

    }
}




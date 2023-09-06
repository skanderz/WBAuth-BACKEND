using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.BO
{
    public class Journalisation{

        public int IdJournalisation { get; set; }
        public string? AdresseIP { get; set; }
        public DateTime DateConnexion { get; set; }

        ICollection<Action>? Actions { get; set; }

    }
}

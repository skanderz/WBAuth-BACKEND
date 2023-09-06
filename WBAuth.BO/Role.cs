using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.BO
{
    public class Role{

        public int IdRole { get; set; }
        public string? Nom { get; set; }
        public int? Niveau { get; set; }
        public string? Description { get; set; }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.BO
{
    public class Application{

        public int IdApplication { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public byte[]? Logo { get; set; }    

    }

}

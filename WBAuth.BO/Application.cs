using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace WBAuth.BO
{
    public class Application{

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public byte[]? Logo { get; set; }

        [JsonIgnore]
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }

        [JsonIgnore]
        public ICollection<Fonction>? Fonctions { get; set; }

        [JsonIgnore]
        public ICollection<Role>? Role { get; set; }

    }

}

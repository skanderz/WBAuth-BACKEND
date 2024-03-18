using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class Journalisation
    {
        public int Id { get; set; }
        public string? Application { get; set; }
        public string? AdresseIP { get; set; }
        public DateTime DateConnexion { get; set; }
        public string? GuidUtilisateur { get; set; }
        [JsonIgnore]
        public Utilisateur? Utilisateur { get; set; }
        [JsonIgnore]
        public ICollection<Action>? Actions { get; set; }

    }
}




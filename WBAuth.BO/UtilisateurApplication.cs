using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class UtilisateurApplication
    {
        public int Id { get; set; }
        public int? IdRole { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }
        public string? GuidUtilisateur { get; set; }
        [JsonIgnore]
        public Utilisateur? Utilisateur { get; set; }
        public int IdApplication { get; set; }
        [JsonIgnore]
        public Application? Application { get; set; }
        public bool Acces { get; set; } = true;

    }
}

using System.Text.Json.Serialization;


namespace WBAuth.DAO.Models
{
    public class Application
    {

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        [JsonIgnore]
        public byte[]? Logo { get; set; }

        [JsonIgnore]
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }

        [JsonIgnore]
        public ICollection<Fonction>? Fonctions { get; set; }

        [JsonIgnore]
        public ICollection<Role>? Role { get; set; }

    }

}

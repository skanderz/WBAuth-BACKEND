using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class Fonction
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public Permission? Permission { get; set; }
        public int IdApplication { get; set; }
        [JsonIgnore]
        public Application? Application { get; set; }

    }
}

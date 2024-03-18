using System.Text.Json.Serialization;

namespace WBAuth.BO
{
    public class Permission
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        [JsonIgnore]
        public Role? Role { get; set; }
        public int IdFonction { get; set; }
        [JsonIgnore]
        public Fonction? Fonction { get; set; }
        public string? Nom { get; set; }
        public string? Status { get; set; } 

    }
}

namespace WBAuth.DAO.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public byte[]? Logo { get; set; }
        public bool Auth2FA { get; set; } = false;
        public bool AuthGoogle { get; set; } = false;
        public bool AuthFacebook { get; set; } = false;
        public bool AuthLinkedIn { get; set; } = false;
        public ICollection<UtilisateurApplication>? UtilisateurApplication { get; set; }
        public ICollection<Fonction>? Fonctions { get; set; }
        public ICollection<Role>? Roles { get; set; }

    }

}

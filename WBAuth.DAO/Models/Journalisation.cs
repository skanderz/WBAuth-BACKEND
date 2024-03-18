namespace WBAuth.DAO.Models
{
    public class Journalisation
    {
        public int Id { get; set; }
        public string? Application { get; set; }
        public string? AdresseIP { get; set; }
        public DateTime DateConnexion { get; set; }
        public string? GuidUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public ICollection<Action>? Actions { get; set; }

    }
}




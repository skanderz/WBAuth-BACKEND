namespace WBAuth.BO
{
    public class Journalisation
    {

        public int IdJournalisation { get; set; }
        public string? AdresseIP { get; set; }
        public DateTime DateConnexion { get; set; }
        public int IdUtilisateur { get; set; }
        public Utilisateur? Utilisateur { get; set; }
        public ICollection<Action>? Actions { get; set; }

    }
}




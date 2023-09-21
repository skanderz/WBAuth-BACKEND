namespace WBAuth.DAO.Models
{
    public class Action
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        public int IdJournalisation { get; set; }
        public Journalisation? Journalisation { get; set; }


    }
}

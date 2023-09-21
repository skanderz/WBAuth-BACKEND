using Action = WBAuth.DAO.Models.Action;


namespace WBAuth.DAO.IRepository
{
    public interface IActionRepositoryDAO
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);

    }
}



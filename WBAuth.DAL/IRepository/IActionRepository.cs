using Action = WBAuth.DAL.Models.Action;


namespace WBAuth.DAL.IRepository
{
    public interface IActionRepository
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);
        Task<Action> Recherche(int Id);
        Task<int> EnregistrementActions(int IdJournalisation);
        Task<bool> Clear(int Id);
       
    }
}



using Action = WBAuth.DAL.Models.Action;


namespace WBAuth.DAL.IRepository
{
    public interface IActionRepository
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);
        Task<IEnumerable<Action>> Recherche(string rech);
        Task<Action> RechercheById(int Id);
        Task<int> EnregistrementActions(Action oAction);
        Task<bool> Clear(int Id);

    }
}



using Action = WBAuth.BO.Action;


namespace WBAuth.BLL.IManager
{
    public interface IActionManager
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);
        Task<Action> RechercheById(int Id);
        Task<IEnumerable<Action>> Recherche(string rech);
        Task<int> EnregistrementActions(Action oAction);
        Task<bool> Clear(int Id);
    }



}



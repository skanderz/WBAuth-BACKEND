using Action = WBAuth.BO.Action;


namespace WBAuth.BLL.IManager
{
    public interface IActionManager
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);
        Task<Action> RechercheById(int Id);
        Task<IEnumerable<Action>> Recherche(string rech);
        Task<int> EnregistrementActions(int IdJournalisation);
        Task<bool> Clear(int Id);
    }



}



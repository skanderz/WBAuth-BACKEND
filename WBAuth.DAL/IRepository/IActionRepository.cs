using Action = WBAuth.DAL.Models.Action;


namespace WBAuth.DAL.IRepository
{
    public interface IActionRepository
    {
        Task<IEnumerable<Action>> RechercheListeAction(DateTime date);
        Task<Action> Recherche(string str);
        Task<int> EnregistrementActions(DateTime date);
        Task<bool> Clear(int Id);
       
    }
}



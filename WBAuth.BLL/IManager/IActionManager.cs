using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Action = WBAuth.BO.Action;


namespace WBAuth.BLL.IManager
{
    public interface IActionManager
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);
        Task<Action> Recherche(int Id);
        Task<int> EnregistrementActions(int IdJournalisation);
        Task<bool> Clear(int Id);
    }



}



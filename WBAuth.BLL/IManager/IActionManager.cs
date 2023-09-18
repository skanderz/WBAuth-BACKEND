using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IActionManager
    {
        Task<IEnumerable<Action>> ChargerAll();
        Task<Action> Recherche(int Id);
        Task<int> Ajouter(Action oAction);
        Task<int> Modifier(Action oAction);
        Task<bool> Suprimer(int Id);
    }



}



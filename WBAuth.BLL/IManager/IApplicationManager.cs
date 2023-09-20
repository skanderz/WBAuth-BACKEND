using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IApplicationManager
    {
        Task<IEnumerable<Application>> ChargerAll();
        Task<Application> Recherche(int Id);
        Task<int> Ajouter(Application oApplication);
        Task<int> Modifier(Application oApplication);
        Task<bool> Supprimer(int Id);
    }



}



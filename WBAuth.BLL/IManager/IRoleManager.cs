using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> ChargerAll(int idApplication);
        Task<Role> Recherche(int Id);
        Task<int> Ajouter(Role oRole);
        Task<int> Modifier(Role oRole);
        Task<bool> Suprimer(int Id);
    }



}



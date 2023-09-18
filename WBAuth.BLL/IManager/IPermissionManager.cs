using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IPermissionManager
    {
        Task<IEnumerable<Permission>> ChargerAll();
        Task<Permission> Recherche(int Id);
        Task<int> Ajouter(Permission oPermission);
        Task<int> Modifier(Permission oPermission);
        Task<bool> Suprimer(int Id);
    }



}



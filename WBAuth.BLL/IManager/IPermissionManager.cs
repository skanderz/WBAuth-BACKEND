using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IPermissionManager
    {
        Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole);
        Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole);
        Task<Permission> RechercheMultiFonction(int Id, int IdApplication, int IdRole);
        Task<Permission> RechercheFonctionUnique(int Id, int IdApplication, int IdRole);
        Task<int> Ajouter(Permission oPermission);
        Task<int> Modifier(Permission oPermission);
        Task<int> ModifierAcces(int Id, int IdApplication, int IdRole);
        Task<bool> Suprimer(int Id, int IdApplication, int IdRole);
    }



}



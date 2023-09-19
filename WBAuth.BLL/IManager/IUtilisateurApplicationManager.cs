using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurApplicationManager
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAll(int IdApplication);
        Task<UtilisateurApplication> Recherche(string NomUtilisateur);
        Task<int> ModifierAccesRole(int IdApplication, int IdUtilisateur, int IdRole);
    }



}



using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurApplicationManager
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAll();
        Task<UtilisateurApplication> Recherche(int Id);
        Task<int> Ajouter(UtilisateurApplication oUtilisateurApplication);
        Task<int> Modifier(UtilisateurApplication oUtilisateurApplication);
        Task<bool> Suprimer(int Id);
    }



}



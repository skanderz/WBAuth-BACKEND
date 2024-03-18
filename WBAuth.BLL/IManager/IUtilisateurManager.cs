using Microsoft.AspNetCore.Identity;
using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurManager
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();
        Task<IEnumerable<Utilisateur>> Recherche(string rech);
        Task<Utilisateur> RechercheById(string id);


    }



}



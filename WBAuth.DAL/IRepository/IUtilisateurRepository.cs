using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurRepository
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();
        Task<Utilisateur> RechercheById(string id);
        Task<IEnumerable<Utilisateur>> Recherche(string rech);

    }
}



using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurRepository
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();
        Task<Utilisateur> RechercheById(int id);
        Task<IEnumerable<Utilisateur>> Recherche(string rech);
        Task<int> Ajouter(Utilisateur oUtilisateur);
        Task<int> Modifier(Utilisateur oUtilisateur);
        Task<bool> Supprimer(int Id);

    }
}



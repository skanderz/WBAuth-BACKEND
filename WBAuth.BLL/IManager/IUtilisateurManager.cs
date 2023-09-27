using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurManager
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();
        Task<IEnumerable<Utilisateur>> Recherche(string rech);
        Task<Utilisateur> RechercheById(int id);
        Task<int> Ajouter(Utilisateur oUtilisateur);
        Task<int> Modifier(Utilisateur oUtilisateur);
        Task<bool> Supprimer(int Id);
    }



}



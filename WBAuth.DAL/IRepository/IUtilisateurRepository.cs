using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurRepository
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();
        Task<Utilisateur> Rechercher(string str);
        Task<int> Ajouter(Utilisateur oUtilisateur);
        Task<int> Modifier(Utilisateur oUtilisateur);
        Task<bool> Suprimer(int Id);
       
    }
}



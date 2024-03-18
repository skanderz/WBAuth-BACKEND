using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurApplicationRepository
    {
        Task<int> Ajouter(UtilisateurApplication oUA);
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication);
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(string IdUtilisateur);
        Task<UtilisateurApplication> Recherche(int Id);
        Task<int> ModifierAccesRole(UtilisateurApplication oUtilisateurApplication);
    }
}



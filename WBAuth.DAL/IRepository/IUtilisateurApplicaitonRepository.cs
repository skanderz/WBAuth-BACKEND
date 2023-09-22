using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurApplicationRepository
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication);
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(int IdUtilisateur);
        Task<UtilisateurApplication> Recherche(int IdUtilisateur, int IdApplication);
        Task<int> ModifierAccesRole(int IdUtilisateur, int IdApplication, bool Acces, string NomRole);

    }
}



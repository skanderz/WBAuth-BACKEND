using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurApplicationRepository
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAll(int IdApplication);
        Task<UtilisateurApplication> Recherche(string NomUtilisateur);
        Task<int> ModifierAccesRole(int IdApplication ,int IdUtilisateur ,int IdRole);
       
    }
}


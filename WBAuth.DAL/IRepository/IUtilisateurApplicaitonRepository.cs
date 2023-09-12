using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IUtilisateurApplicationRepository
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAll(int IdApplication);
        Task<UtilisateurApplication> Rechercher(string NomUtilisateur);
        Task<int> ModifierAccesRole(int IdUtilisateur);
       
    }
}




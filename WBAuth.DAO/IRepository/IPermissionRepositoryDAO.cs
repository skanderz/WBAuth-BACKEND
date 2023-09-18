using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IPermissionRepositoryDAO
    {
        Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication ,int IdRole);
        Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole);

       
    }
}


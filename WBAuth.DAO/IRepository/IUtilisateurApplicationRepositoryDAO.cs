using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IUtilisateurApplicationRepositoryDAO
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAll(int IdApplication);


    }
}


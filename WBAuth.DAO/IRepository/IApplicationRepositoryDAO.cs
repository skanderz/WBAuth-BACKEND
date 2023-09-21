using WBAuth.DAO.Models;

namespace WBAuth.DAO.IRepository
{
    public interface IApplicationRepositoryDAO
    {
        Task<IEnumerable<Application>> ChargerAll();

    }
}

using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IRoleRepositoryDAO
    {
        Task<IEnumerable<Role>> ChargerAll(int idApplication);


    }
}



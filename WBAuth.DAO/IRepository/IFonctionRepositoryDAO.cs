using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IFonctionRepositoryDAO
    {
        Task<IEnumerable<Fonction>> ChargerAll(int IdApplication);


    }
}

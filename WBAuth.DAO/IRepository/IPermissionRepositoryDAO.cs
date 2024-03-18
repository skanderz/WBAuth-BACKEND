using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IPermissionRepositoryDAO
    {

        Task<IEnumerable<Permission>> RechercheMultiFonction(string rech, int IdApplication, int IdRole);

        Task<IEnumerable<Permission>> RechercheFonctionUnique(string rech, int IdApplication, int IdRole);


    }
}


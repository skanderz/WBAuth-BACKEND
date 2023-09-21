using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;

namespace WBAuth.DAO.Repository
{

    public class PermissionRepositoryDAO : IPermissionRepositoryDAO
    {



        public Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }



    }
}




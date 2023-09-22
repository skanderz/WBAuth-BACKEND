using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;

namespace WBAuth.DAO.Repository
{

    public class ApplicationRepositoryDAO : IApplicationRepositoryDAO
    {
        #region Déclaration


        //private readonly IApplicationRepositoryDAO _ApplicationRepository;
        //#endregion Déclaration
        //#region Constructeur
        //public ApplicationRepositoryDAO(IApplicationRepositoryDAO ApplicationRepository)
        //{
        //    _ApplicationRepository = ApplicationRepository;
        //}


        #endregion Constructeur
        public Task<IEnumerable<Application>> ChargerAll()
        {
            throw new NotImplementedException();
        }
    }
}




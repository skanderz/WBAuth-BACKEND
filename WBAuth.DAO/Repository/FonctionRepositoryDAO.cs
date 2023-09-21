using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;

namespace WBAuth.DAO.Repository
{

    public class FonctionRepositoryDAO : IFonctionRepositoryDAO
    {
        #region Déclaration


        //private readonly IFonctionRepositoryDAO _FonctionRepository;
        //#endregion Déclaration
        //#region Constructeur
        //public FonctionRepositoryDAO(IFonctionRepositoryDAO FonctionRepository)
        //{
        //    _FonctionRepository = FonctionRepository;
        //}


        #endregion Constructeur

        public Task<IEnumerable<Fonction>> ChargerAll(int IdApplication)
        {
            throw new NotImplementedException();
        }




    }
}




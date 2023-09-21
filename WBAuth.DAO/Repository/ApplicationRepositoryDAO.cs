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

        public async Task<IEnumerable<Application>> ChargerAll()
        {
            //return await _dataContext.Set<Application>().ToListAsync();

            List<Application> cListApplication = new List<Application>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [IdApplication],[Nom],[Description],[Url]";
            sql += " FROM  [Application] ";
            using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
            {
                conSQL.Open();
                using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                {
                    using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                    {
                        while (drSQL.Read())
                        {
                            Application oApplication = new Application();
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oApplication.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("Description"))) oApplication.Description = drSQL.GetString(drSQL.GetOrdinal("Description"));
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("Url"))) oApplication.Url = drSQL.GetString(drSQL.GetOrdinal("Url"));
                            cListApplication.Add(oApplication);
                        }
                    }
                }
                conSQL.Close();
            }
            await Task.Delay(1000);
            return cListApplication;
        }




    }
}




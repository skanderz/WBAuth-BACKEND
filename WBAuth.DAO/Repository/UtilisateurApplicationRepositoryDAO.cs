using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;

namespace WBAuth.DAO.Repository
{

    public class UtilisateurApplicationRepositoryDAO : IUtilisateurApplicationRepositoryDAO
    {
        #region Déclaration


        //private readonly IUtilisateurApplicationRepositoryDAO _UtilisateurApplicationRepository;
        //#endregion Déclaration
        //#region Constructeur
        //public UtilisateurApplicationRepositoryDAO(IUtilisateurApplicationRepositoryDAO UtilisateurApplicationRepository)
        //{
        //    _UtilisateurApplicationRepository = UtilisateurApplicationRepository;
        //}


        #endregion Constructeur

        public async Task<IEnumerable<UtilisateurApplication>> ChargerAll(int IdApplication)
        {
            //return await _dataContext.Set<UtilisateurApplication>().ToListAsync();

            List<UtilisateurApplication> cListUtilisateurApplication = new List<UtilisateurApplication>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [IdUtilisateur],[IdApplication],[IdRole]";
            sql += " FROM  [UtilisateurApplication] ";
            using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
            {
                conSQL.Open();
                using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                {
                    using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                    {
                        while (drSQL.Read())
                        {
                            UtilisateurApplication oUtilisateurApplication = new UtilisateurApplication();
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("IdUtilisateur"))) oUtilisateurApplication.IdUtilisateur = drSQL.GetOrdinal("IdUtilisateur");
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("IdApplication"))) oUtilisateurApplication.IdApplication = drSQL.GetOrdinal("IdApplication");
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("IdRole"))) oUtilisateurApplication.IdRole = drSQL.GetOrdinal("IdRole");
                            cListUtilisateurApplication.Add(oUtilisateurApplication);
                        }
                    }
                }
                conSQL.Close();
            }
            await Task.Delay(1000);
            return cListUtilisateurApplication;
        }


    }
}




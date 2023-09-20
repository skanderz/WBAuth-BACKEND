using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            sql = "SELECT top 10 [IdUtilisateurApplication],[Nom],[Description],[Url]";
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
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oUtilisateurApplication.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Description"))) oUtilisateurApplication.Description = drSQL.GetString(drSQL.GetOrdinal("Description"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Url"))) oUtilisateurApplication.Url = drSQL.GetString(drSQL.GetOrdinal("Url"));
                            cListUtilisateurApplication.Add(oUtilisateurApplication);
                            }
                        }
                    }
                    conSQL.Close();
                }
            await Task.Delay(1000);
            return  cListUtilisateurApplication;
            }


    }
}




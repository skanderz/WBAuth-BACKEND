using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Fonction>> ChargerAll(int IdApplication)
        {
                //return await _dataContext.Set<Fonction>().ToListAsync();

                List<Fonction> cListFonction = new List<Fonction>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [IdFonction],[Nom],[Description],[Url]";
            sql += " FROM  [Fonction] ";
                using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
                {
                    conSQL.Open();
                    using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                    {
                        using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                        {
                            while (drSQL.Read())
                            {
                                Fonction oFonction = new Fonction();
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oFonction.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Description"))) oFonction.Description = drSQL.GetString(drSQL.GetOrdinal("Description"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Url"))) oFonction.Url = drSQL.GetString(drSQL.GetOrdinal("Url"));
                            cListFonction.Add(oFonction);
                            }
                        }
                    }
                    conSQL.Close();
                }
            await Task.Delay(1000);
            return  cListFonction;
            }




        }
}




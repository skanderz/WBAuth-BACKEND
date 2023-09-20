using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Repository
{

        public class JournalisationRepositoryDAO : IJournalisationRepositoryDAO
        {


        public async Task<IEnumerable<Journalisation>> ChargerListe(string NomUtilisateur)
        {
                //return await _dataContext.Set<Journalisation>().ToListAsync();

                List<Journalisation> cListJournalisation = new List<Journalisation>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [IdJournalisation],[Nom],[Description],[Url]";
            sql += " FROM  [Journalisation] ";
                using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
                {
                    conSQL.Open();
                    using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                    {
                        using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                        {
                            while (drSQL.Read())
                            {
                                Journalisation oJournalisation = new Journalisation();
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oJournalisation.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Description"))) oJournalisation.Description = drSQL.GetString(drSQL.GetOrdinal("Description"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Url"))) oJournalisation.Url = drSQL.GetString(drSQL.GetOrdinal("Url"));
                            cListJournalisation.Add(oJournalisation);
                            }
                        }
                    }
                    conSQL.Close();
                }
            await Task.Delay(1000);
            return  cListJournalisation;
            }


   
        }
}




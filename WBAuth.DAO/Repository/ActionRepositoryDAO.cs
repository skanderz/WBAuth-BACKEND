using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Action = WBAuth.DAO.Models.Action;


namespace WBAuth.DAO.Repository
{

        public class ActionRepositoryDAO : IActionRepositoryDAO
        {
        #region Déclaration


        //private readonly IActionRepositoryDAO _ActionRepository;
        //#endregion Déclaration
        //#region Constructeur
        //public ActionRepositoryDAO(IActionRepositoryDAO ActionRepository)
        //{
        //    _ActionRepository = ActionRepository;
        //}


        #endregion Constructeur

        public async Task<IEnumerable<Action>> ChargerListe(int IdJournalisation)
        {
                //return await _dataContext.Set<Action>().ToListAsync();

                List<Action> cListAction = new List<Action>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [IdAction],[Nom],[Description],[Url]";
            sql += " FROM  [Action] ";
                using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
                {
                    conSQL.Open();
                    using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                    {
                        using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                        {
                            while (drSQL.Read())
                            {
                                Action oAction = new Action();
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oAction.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Description"))) oAction.Description = drSQL.GetString(drSQL.GetOrdinal("Description"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Url"))) oAction.Url = drSQL.GetString(drSQL.GetOrdinal("Url"));
                            cListAction.Add(oAction);
                            }
                        }
                    }
                    conSQL.Close();
                }
            await Task.Delay(1000);
            return  cListAction;
            }




    }
    }




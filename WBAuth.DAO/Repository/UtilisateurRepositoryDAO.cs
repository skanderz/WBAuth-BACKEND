using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Repository
{

        public class UtilisateurRepositoryDAO : IUtilisateurRepositoryDAO
        {
            #region Déclaration


            //private readonly IUtilisateurRepositoryDAO _UtilisateurRepository;
            //#endregion Déclaration
            //#region Constructeur
            //public UtilisateurRepositoryDAO(IUtilisateurRepositoryDAO UtilisateurRepository)
            //{
            //    _UtilisateurRepository = UtilisateurRepository;
            //}


            #endregion Constructeur

            public async Task<IEnumerable<Utilisateur>> ChargerAll()
            {
                //return await _dataContext.Set<Utilisateur>().ToListAsync();

                List<Utilisateur> cListUtilisateur = new List<Utilisateur>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [IdUtilisateur],[Nom],[Description],[Url]";
            sql += " FROM  [Utilisateur] ";
                using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
                {
                    conSQL.Open();
                    using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                    {
                        using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                        {
                            while (drSQL.Read())
                            {
                                Utilisateur oUtilisateur = new Utilisateur();
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oUtilisateur.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Description"))) oUtilisateur.Description = drSQL.GetString(drSQL.GetOrdinal("Description"));
                                if (!drSQL.IsDBNull(drSQL.GetOrdinal("Url"))) oUtilisateur.Url = drSQL.GetString(drSQL.GetOrdinal("Url"));
                            cListUtilisateur.Add(oUtilisateur);
                            }
                        }
                    }
                    conSQL.Close();
                }
            await Task.Delay(1000);
            return  cListUtilisateur;
            }




        }
    }




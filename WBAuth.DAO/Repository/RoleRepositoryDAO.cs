﻿using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;

namespace WBAuth.DAO.Repository
{

    public class RoleRepositoryDAO : IRoleRepositoryDAO
    {
        #region Déclaration


        //private readonly IRoleRepositoryDAO _RoleRepository;
        //#endregion Déclaration
        //#region Constructeur
        //public RoleRepositoryDAO(IRoleRepositoryDAO RoleRepository)
        //{
        //    _RoleRepository = RoleRepository;
        //}


        #endregion Constructeur

        public async Task<IEnumerable<Role>> ChargerAll(int idApplication)
        {
            //return await _dataContext.Set<Role>().ToListAsync();

            List<Role> cListRole = new List<Role>();
            String sql = String.Empty;
            //Chaine de connexion
            string strConnexionString = "Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true";

            //requête
            sql = "SELECT top 10 [Id],[Nom],[Niveau]";
            sql += " FROM  [Role] ";
            using (System.Data.SqlClient.SqlConnection conSQL = new System.Data.SqlClient.SqlConnection(strConnexionString))
            {
                conSQL.Open();
                using (System.Data.SqlClient.SqlCommand comSQL = new System.Data.SqlClient.SqlCommand(sql, conSQL))
                {
                    using (System.Data.SqlClient.SqlDataReader drSQL = comSQL.ExecuteReader())
                    {
                        while (drSQL.Read())
                        {
                            Role oRole = new Role();
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("Nom"))) oRole.Nom = drSQL.GetString(drSQL.GetOrdinal("Nom"));
                            if (!drSQL.IsDBNull(drSQL.GetOrdinal("Niveau"))) oRole.Niveau = drSQL.GetOrdinal("Niveau");
                            cListRole.Add(oRole);
                        }
                    }
                }
                conSQL.Close();
            }
            await Task.Delay(1000);
            return cListRole;
        }


    }
}




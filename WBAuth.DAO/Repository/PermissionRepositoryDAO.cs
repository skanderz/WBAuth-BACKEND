using System.Data.SqlClient;
using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;

namespace WBAuth.DAO.Repository
{

    public class PermissionRepositoryDAO : IPermissionRepositoryDAO
    {

        public async Task<IEnumerable<Permission>> RechercheMultiFonction(string rech, int IdApplication, int IdRole)
        {
            List<Permission> perms = new List<Permission>();
            using (SqlConnection connection = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                connection.Open();

                string selectQuery = @" SELECT p.Id, p.IdRole, p.Nom, p.IdFonction ,p.Status
                                        FROM Permission AS p INNER JOIN Fonction AS f ON p.IdFonction = f.Id
                                        WHERE p.IdRole = @IdRole AND p.Nom = @rech AND f.IdApplication = @IdApplication AND f.Type = 'Multifonctions'";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@IdRole", IdRole);
                    selectCommand.Parameters.AddWithValue("@rech", rech);
                    selectCommand.Parameters.AddWithValue("@IdApplication", IdApplication);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permission permission = new Permission
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                IdRole = reader.GetInt32(reader.GetOrdinal("IdRole")),
                                Nom = reader.GetString(reader.GetOrdinal("Nom")),
                                IdFonction = reader.GetInt32(reader.GetOrdinal("IdFonction")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };
                            perms.Add(permission);
                        }
                    }
                }
            }
            await Task.Delay(1000);
            return perms;
        }


        public async Task<IEnumerable<Permission>> RechercheFonctionUnique(string rech, int IdApplication, int IdRole)
        {
            List<Permission> perms = new List<Permission>();
            using (SqlConnection connection = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=WBAuth; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                connection.Open();

                string selectQuery = @" SELECT p.Id, p.IdRole, p.Nom, p.IdFonction ,p.Status
                                        FROM Permission AS p INNER JOIN Fonction AS f ON p.IdFonction = f.Id
                                        WHERE p.IdRole = @IdRole AND p.Nom = @rech AND f.IdApplication = @IdApplication AND f.Type = 'Fonction Unique'";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@IdRole", IdRole);
                    selectCommand.Parameters.AddWithValue("@rech", rech);
                    selectCommand.Parameters.AddWithValue("@IdApplication", IdApplication);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Permission permission = new Permission
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                IdRole = reader.GetInt32(reader.GetOrdinal("IdRole")),
                                Nom = reader.GetString(reader.GetOrdinal("Nom")),
                                IdFonction = reader.GetInt32(reader.GetOrdinal("IdFonction")),
                                Status = reader.GetString(reader.GetOrdinal("Status"))
                            };
                            perms.Add(permission);
                        }
                    }
                }
            }
            await Task.Delay(1000);
            return perms;
        }




    }
}




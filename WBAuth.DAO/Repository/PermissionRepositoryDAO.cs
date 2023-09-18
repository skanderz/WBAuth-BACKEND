using WBAuth.DAO.IRepository;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.Repository
{

        public class PermissionRepositoryDAO : IPermissionRepositoryDAO
        {

   

        public Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }



    }
}




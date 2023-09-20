using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WBAuth.DAO.IRepository
{
   public interface IApplicationRepositoryDAO
    {
        Task<IEnumerable<Application>> ChargerAll();
       
    }
}

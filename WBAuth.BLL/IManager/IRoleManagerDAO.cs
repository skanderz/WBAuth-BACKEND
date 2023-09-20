using WBAuth.BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace WBAuth.BLL.IManager
{
    public interface IRoleManagerDAO
    {
        Task<IEnumerable<Role>> ChargerAll();
      
    }
}

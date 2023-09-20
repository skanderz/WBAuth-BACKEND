using WBAuth.BO;
using Action = WBAuth.BO.Action;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IActionManagerDAO
    {
        Task<IEnumerable<Action>> ChargerAll();
      
    }
}

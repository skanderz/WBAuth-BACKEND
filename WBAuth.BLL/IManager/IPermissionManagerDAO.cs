using WBAuth.BO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IPermissionManagerDAO
    {

        Task<IEnumerable<Permission>> RechercheMultiFonction(string rech, int IdApplication, int IdRole);
        Task<IEnumerable<Permission>> RechercheFonctionUnique(string rech, int IdApplication, int IdRole);

    }
}
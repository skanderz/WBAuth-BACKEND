using Action = WBAuth.DAO.Models.Action;
using WBAuth.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace WBAuth.DAO.IRepository
{
    public interface IActionRepositoryDAO
    {
        Task<IEnumerable<Action>> ChargerListe(int IdJournalisation);
       
    }
}



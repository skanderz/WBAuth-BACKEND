using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IJournalisationManager
    {
        Task<IEnumerable<Journalisation>> ChargerAll();
        Task<Journalisation> Recherche(int Id);
        Task<int> Ajouter(Journalisation oJournalisation);
        Task<int> Modifier(Journalisation oJournalisation);
        Task<bool> Suprimer(int Id);
    }



}



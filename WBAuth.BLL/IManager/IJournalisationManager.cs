using WBAuth.BO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.IManager
{
    public interface IJournalisationManager
    {
        Task<IEnumerable<Journalisation>> ChargerListe(string NomUtilisateur);
        Task<Journalisation> Recherche(int Id);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int Id);
    }



}



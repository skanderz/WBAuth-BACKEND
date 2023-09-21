using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IJournalisationManager
    {
        Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur);
        Task<Journalisation> Recherche(int Id);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int IdUtilisateur);
    }



}



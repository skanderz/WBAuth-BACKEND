using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IJournalisationManager
    {
        Task<IEnumerable<Journalisation>> ChargerListe(string GuidUtilisateur);
        Task<Journalisation> RechercheById(int Id);
        Task<IEnumerable<Journalisation>> Recherche(string rech);
        Task<int> EnregistrementJournalisation(Journalisation oJournalisation);
        Task<bool> Clear(string GuidUtilisateur);
    }



}



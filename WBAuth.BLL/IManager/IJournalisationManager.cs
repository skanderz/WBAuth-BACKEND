using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IJournalisationManager
    {
        Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur);
        Task<Journalisation> RechercheById(int Id);
        Task<IEnumerable<Journalisation>> Recherche(string rech);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int IdUtilisateur);
    }



}



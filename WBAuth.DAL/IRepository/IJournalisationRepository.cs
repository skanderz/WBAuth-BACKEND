using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IJournalisationRepository
    {
        Task<IEnumerable<Journalisation>> ChargerListe(string GuidUtilisateur);
        Task<Journalisation> RechercheById(int Id);
        Task<IEnumerable<Journalisation>> Recherche(string rech);
        Task<int> EnregistrementJournalisation(Journalisation oJournalisation);
        Task<bool> Clear(string GuidUtilisateur);

    }
}



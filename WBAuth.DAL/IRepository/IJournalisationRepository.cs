using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IJournalisationRepository
    {
        Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur);
        Task<Journalisation> RechercheById(int Id);
        Task<IEnumerable<Journalisation>> Recherche(string rech);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int Id);

    }
}



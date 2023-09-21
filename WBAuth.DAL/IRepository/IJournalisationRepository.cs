using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IJournalisationRepository
    {
        Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur);
        Task<Journalisation> Recherche(int Id);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int Id);

    }
}



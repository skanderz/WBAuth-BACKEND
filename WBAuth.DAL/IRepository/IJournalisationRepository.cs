using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IJournalisationRepository
    {
        Task<IEnumerable<Journalisation>> ChargerListe(string NomUtilisateur);
        Task<Journalisation> Recherche(int Id);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int Id);
       
    }
}



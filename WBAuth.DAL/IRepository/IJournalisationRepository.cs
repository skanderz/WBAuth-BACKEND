using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IJournalisationRepository
    {
        Task<IEnumerable<Journalisation>> RechercheListeJournalisation(string NomUtilisateur);
        Task<Journalisation> Recherche(string str);
        Task<int> EnregistrementJournalisation(int IdUtilisateur);
        Task<bool> Clear(int Id);
       
    }
}



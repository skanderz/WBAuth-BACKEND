using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IJournalisationRepositoryDAO
    {
        Task<IEnumerable<Journalisation>> ChargerListe(string NomUtilisateur);

    }
}



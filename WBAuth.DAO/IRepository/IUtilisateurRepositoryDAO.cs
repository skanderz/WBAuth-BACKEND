using WBAuth.DAO.Models;


namespace WBAuth.DAO.IRepository
{
    public interface IUtilisateurRepositoryDAO
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();


    }
}



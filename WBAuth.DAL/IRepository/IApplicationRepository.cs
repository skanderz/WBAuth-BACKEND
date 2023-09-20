using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<Application>> ChargerAll();
        Task<Application> Recherche(int Id);
        Task<int> Ajouter(Application oApplication);
        Task<int> Modifier(Application oApplication);
        Task<bool> Supprimer(int Id);
       
    }
}



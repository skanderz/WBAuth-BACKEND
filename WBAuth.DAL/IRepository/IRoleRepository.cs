using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> ChargerAll(int idApplication);
        Task<Role> Recherche(int Id);
        Task<int> Ajouter(Role oRole);
        Task<int> Modifier(Role oRole);
        Task<bool> Supprimer(int Id);
       
    }
}



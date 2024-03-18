using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> ChargerAll(int idApplication);
        Task<IEnumerable<Role>> Recherche(string rech,int IdApplication);
        Task<Role> RechercheById(int Id);
        Task<int> Ajouter(Role oRole);
        Task<int> Modifier(Role oRole);
        Task<bool> Supprimer(int Id);

    }
}



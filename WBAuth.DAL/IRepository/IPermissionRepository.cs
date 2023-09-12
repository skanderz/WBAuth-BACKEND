using WBAuth.DAL.Models;


namespace WBAuth.DAL.IRepository
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> ChargerAll();
        Task<Permission> Recherche(int Id);
        Task<int> Ajouter(Permission oPermission);
        Task<int> Modifier(Permission oPermission);
        Task<bool> Suprimer(int Id);
       
    }
}

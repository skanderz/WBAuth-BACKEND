using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IPermissionManager
    {
        Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole);
        Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole);
        Task<Permission> RechercheMultiFonctionById(int Id, int IdApplication, int IdRole);
        Task<Permission> RechercheFonctionUniqueById(int Id, int IdApplication, int IdRole);
        Task<IEnumerable<Permission>> RechercheMultiFonction(string rech, int IdApplication, int IdRole);
        Task<IEnumerable<Permission>> RechercheFonctionUnique(string rech, int IdApplication, int IdRole);
        Task<int> Ajouter(Permission oPermission);
        Task<int> Modifier(Permission oPermission, string type);
        Task<int> ModifierAcces(int Id, int IdApplication, int IdRole, int i);
        Task<bool> Supprimer(int Id);
    }



}



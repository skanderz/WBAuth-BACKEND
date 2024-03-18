using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> ChargerAll(int IdApplication);
        Task<IEnumerable<Role>> Recherche(string rech, int IdApplication);
        Task<Role> RechercheById(int Id);
        Task<int> Ajouter(Role oRole);
        Task<int> Modifier(Role oRole);
        Task<bool> Supprimer(int Id);
    }



}



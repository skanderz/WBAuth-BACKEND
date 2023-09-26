using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IApplicationManager
    {
        Task<IEnumerable<Application>> ChargerAll();
        Task<IEnumerable<Application>> Recherche(string str);
        Task<Application> RechercheById(int Id);
        Task<int> Ajouter(Application oApplication);
        Task<int> Modifier(Application oApplication);
        Task<bool> Supprimer(int Id);
    }



}



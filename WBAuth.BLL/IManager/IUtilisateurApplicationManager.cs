using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurApplicationManager
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication);
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(string GuidUtilisateur);
        Task<UtilisateurApplication> Recherche(int Id);
        Task<int> Ajouter(UtilisateurApplication oUtilisateurApplication);
        Task<int> ModifierAccesRole(UtilisateurApplication oUtilisateurApplication);
    }



}



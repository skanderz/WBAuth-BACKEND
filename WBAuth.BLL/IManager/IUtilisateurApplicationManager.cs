using WBAuth.BO;


namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurApplicationManager
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication);
        Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(int IdUtilisateur);
        Task<UtilisateurApplication> Recherche(int IdUtilisateur, int IdApplication);
        Task<int> ModifierAccesRole(int IdUtilisateur, int IdApplication, bool Acces, string NomRole);
    }



}



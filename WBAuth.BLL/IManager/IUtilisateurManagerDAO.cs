using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurManagerDAO
    {
        Task<IEnumerable<Utilisateur>> ChargerAll();

    }
}

using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IUtilisateurApplicationManagerDAO
    {
        Task<IEnumerable<UtilisateurApplication>> ChargerAll();

    }
}

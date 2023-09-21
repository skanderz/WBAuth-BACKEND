using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IFonctionManagerDAO
    {
        Task<IEnumerable<Fonction>> ChargerAll();

    }
}

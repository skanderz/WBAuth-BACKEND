using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IApplicationManagerDAO
    {
        Task<IEnumerable<Application>> ChargerAll();

    }
}

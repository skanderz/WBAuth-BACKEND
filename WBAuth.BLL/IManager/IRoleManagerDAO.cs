using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IRoleManagerDAO
    {
        Task<IEnumerable<Role>> ChargerAll();

    }
}

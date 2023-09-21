using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IPermissionManagerDAO
    {
        Task<IEnumerable<Permission>> ChargerAll();

    }
}

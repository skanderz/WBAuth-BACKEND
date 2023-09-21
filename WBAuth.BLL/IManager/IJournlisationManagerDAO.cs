using WBAuth.BO;



namespace WBAuth.BLL.IManager
{
    public interface IJournalisationManagerDAO
    {
        Task<IEnumerable<Journalisation>> ChargerAll();

    }
}

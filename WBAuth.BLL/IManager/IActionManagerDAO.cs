using Action = WBAuth.BO.Action;


namespace WBAuth.BLL.IManager
{
    public interface IActionManagerDAO
    {
        Task<IEnumerable<Action>> ChargerAll(int IdJournalisation);

    }
}

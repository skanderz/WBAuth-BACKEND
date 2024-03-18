using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Action = WBAuth.DAL.Models.Action;



namespace WBAuth.DAL.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public ActionRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }


        public async Task<IEnumerable<Action>> ChargerListe(int IdJournalisation) { return await _dataContext.Set<Action>().Where(a => a.IdJournalisation == IdJournalisation).ToListAsync(); }


        public async Task<int> EnregistrementActions(Action oAction)
        {
            if (oAction == null) throw new ArgumentNullException(nameof(oAction));
            _dataContext.Entry(oAction).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oAction.Id;
        }


        public async Task<IEnumerable<Action>> Recherche(string rech)
        {
            DateTime parsedDate = DateTime.Parse(rech);
            var Actions = await _dataContext.Set<Action>().Where(a => a.Description == rech || a.Application == rech || a.Date == parsedDate).ToListAsync();
            if (Actions == null) { Console.Error.WriteLine("Liste Introuvable."); }
            return Actions;
        }


        public async Task<Action> RechercheById(int Id)
        {
            var oAction = await _dataContext.Set<Action>().FirstOrDefaultAsync(a => a.Id == Id);
            if (oAction == null) { Console.Error.WriteLine("Aucun élément trouvé avec l'ID spécifié."); }
            return oAction;
        }


        public async Task<bool> Clear(int IdJournalisation)
        {
            if (IdJournalisation <= 0) throw new ArgumentException("IdJournalisation doit être supérieur à zéro.", nameof(IdJournalisation));
            var actions = await _dataContext.Set<Action>().Where(a => a.IdJournalisation == IdJournalisation).ToListAsync();
            if (actions.Any()) { _dataContext.RemoveRange(actions); await _dataContext.SaveChangesAsync(); }
            return true;
        }



    }
}



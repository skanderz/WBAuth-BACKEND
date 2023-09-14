using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Action = WBAuth.DAL.Models.Action;



namespace WBAuth.DAL.Repository
{
    public class ActionRepository : IActionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public ActionRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }




        public async Task<IEnumerable<Action>> ChargerListe(int IdJournalisation){    return await _dataContext.Set<Action>().ToListAsync();   }


        /* ajouter task et async */
        public Task<int> EnregistrementActions(int IdJournalisation)
        {
            throw new NotImplementedException();
        }
         


        public async Task<Action> Recherche(int Id)
        {
            return await _dataContext.Set<Action>().FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<bool> Clear(int IdJournalisation)
        {
            if (IdJournalisation <= 0) throw new ArgumentException("IdJournalisation doit être supérieur à zéro.", nameof(IdJournalisation));
            var actions = await _dataContext.Action.Where(a => a.IdJournalisation == IdJournalisation).ToListAsync();
            if (actions.Any()){  _dataContext.RemoveRange(actions);    await _dataContext.SaveChangesAsync();    }
            return true;
        }



    }
}



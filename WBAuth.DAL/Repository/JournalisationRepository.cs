using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Journalisation = WBAuth.DAL.Models.Journalisation;



namespace WBAuth.DAL.Repository
{
    public class JournalisationRepository : IJournalisationRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public JournalisationRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }


        public async Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur)
        {
            return await _dataContext.Set<Journalisation>().Where(j => j.IdUtilisateur == IdUtilisateur).ToListAsync();
        }

        public async Task<Journalisation> Recherche(int Id)
        {
            var oJournalisation = await _dataContext.Set<Journalisation>().FirstOrDefaultAsync(j => j.Id == Id);
            if (oJournalisation == null) Console.Error.WriteLine("Aucun élément trouvé avec l'ID spécifié.");
            return oJournalisation;  
        }


        public async Task<int> EnregistrementJournalisation(int IdUtilisateur)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Clear(int IdUtilisateur)
        {
            if (IdUtilisateur <= 0) throw new ArgumentException("IdUtilisateur doit être supérieur à zéro.", nameof(IdUtilisateur));
            var journalisations = await _dataContext.Set<Journalisation>().Where(a => a.IdUtilisateur == IdUtilisateur).ToListAsync();
            if (journalisations.Any()) { _dataContext.RemoveRange(journalisations); await _dataContext.SaveChangesAsync(); }
            return true;
        }





    }
}



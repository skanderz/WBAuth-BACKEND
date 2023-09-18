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



        public async Task<IEnumerable<Journalisation>> ChargerAll() { return await _dataContext.Set<Journalisation>().ToListAsync(); }



        public async Task<int> Ajouter(Journalisation oJournalisation)
        {
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            _dataContext.Entry(oJournalisation).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oJournalisation.Id;
        }

        public async  Task<int> Modifier(Journalisation oJournalisation)
        {
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            var entity = await _dataContext.Set<Journalisation>().FirstOrDefaultAsync(item => item.Id == oJournalisation.Id);
            entity.Nom = oJournalisation.Nom;
            entity.Description = oJournalisation.Description;
            entity.Url = oJournalisation.Url;
            entity.Logo = oJournalisation.Logo;
            _dataContext.Entry<Journalisation>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oJournalisation.Id;
        }


        public async Task<bool> Suprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Journalisation>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<Journalisation>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Journalisation> Recherche(int Id)
        {
            return await _dataContext.Set<Journalisation>().FirstOrDefaultAsync(item => item.Id == Id);
        }

        public Task<IEnumerable<Journalisation>> ChargerListe(string NomUtilisateur)
        {
            throw new NotImplementedException();
        }

        public Task<int> EnregistrementJournalisation(int IdUtilisateur)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Clear(int Id)
        {
            throw new NotImplementedException();
        }
    }
}



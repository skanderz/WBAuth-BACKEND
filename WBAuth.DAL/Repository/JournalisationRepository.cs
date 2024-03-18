using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Journalisation = WBAuth.DAL.Models.Journalisation;



namespace WBAuth.DAL.Repository
{
    public class JournalisationRepository : IJournalisationRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public JournalisationRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }


        public async Task<IEnumerable<Journalisation>> ChargerListe(string IdU)
        {
            return await _dataContext.Set<Journalisation>().Where(j => j.GuidUtilisateur == IdU).ToListAsync();
        }

        public async Task<IEnumerable<Journalisation>> Recherche(string rech)
        {
            DateTime parsedDate = DateTime.Parse(rech);
            var Journalisations = await _dataContext.Set<Journalisation>().Where(j => j.DateConnexion == parsedDate || j.AdresseIP == rech).ToListAsync();
            if (Journalisations == null) throw new Exception("Liste Introuvable.");
            return Journalisations;
        }

        public async Task<Journalisation> RechercheById(int Id)
        {
            var oJournalisation = await _dataContext.Set<Journalisation>().FirstOrDefaultAsync(j => j.Id == Id);
            if (oJournalisation == null) throw new Exception("Aucun élément trouvé avec l'ID spécifié.");
            return oJournalisation;
        }


        public async Task<int> EnregistrementJournalisation(Journalisation oJournalisation)
        {
            if (oJournalisation == null) throw new ArgumentNullException(nameof(oJournalisation));
            _dataContext.Entry(oJournalisation).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oJournalisation.Id;
        }


        public async Task<bool> Clear(string IdU)
        {
            if (IdU == null) throw new ArgumentException("IdUtilisateur introuvable", nameof(IdU));
            var journalisations = await _dataContext.Set<Journalisation>().Where(a => a.GuidUtilisateur == IdU).ToListAsync();
            if (journalisations.Any()) { _dataContext.RemoveRange(journalisations); await _dataContext.SaveChangesAsync(); }
            return true;
        }





    }
}



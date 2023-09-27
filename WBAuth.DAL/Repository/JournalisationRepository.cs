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


        public async Task<IEnumerable<Journalisation>> ChargerListe(int IdUtilisateur)
        {
            return await _dataContext.Set<Journalisation>().Where(j => j.IdUtilisateur == IdUtilisateur).ToListAsync();
        }

        public async Task<IEnumerable<Journalisation>> Recherche(string rech)
        {
            DateTime parsedDate = DateTime.Parse(rech);
            var Journalisations = await _dataContext.Set<Journalisation>().Where(j => j.DateConnexion == parsedDate || j.AdresseIP == rech).ToListAsync();
            if (Journalisations == null) Console.Error.WriteLine("Liste Introuvable.");
            return Journalisations;
        }

        public async Task<Journalisation> RechercheById(int Id)
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



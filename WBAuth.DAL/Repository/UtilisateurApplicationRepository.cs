using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using UtilisateurApplication = WBAuth.DAL.Models.UtilisateurApplication;



namespace WBAuth.DAL.Repository
{
    public class UtilisateurApplicationRepository : IUtilisateurApplicationRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public UtilisateurApplicationRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }



        public async Task<IEnumerable<UtilisateurApplication>> ChargerAll() { return await _dataContext.Set<UtilisateurApplication>().ToListAsync(); }



        public async Task<int> Ajouter(UtilisateurApplication oUtilisateurApplication)
        {
            if (oUtilisateurApplication == null) throw new ArgumentNullException(nameof(oUtilisateurApplication));
            _dataContext.Entry(oUtilisateurApplication).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oUtilisateurApplication.Id;
        }

        public async  Task<int> Modifier(UtilisateurApplication oUtilisateurApplication)
        {
            if (oUtilisateurApplication == null) throw new ArgumentNullException(nameof(oUtilisateurApplication));
            var entity = await _dataContext.Set<UtilisateurApplication>().FirstOrDefaultAsync(item => item.Id == oUtilisateurApplication.Id);
            entity.Nom = oUtilisateurApplication.Nom;
            entity.Description = oUtilisateurApplication.Description;
            entity.Url = oUtilisateurApplication.Url;
            entity.Logo = oUtilisateurApplication.Logo;
            _dataContext.Entry<UtilisateurApplication>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oUtilisateurApplication.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<UtilisateurApplication>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<UtilisateurApplication>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<UtilisateurApplication> Recherche(int Id)
        {
            return await _dataContext.Set<UtilisateurApplication>().FirstOrDefaultAsync(item => item.Id == Id);
        }

        public async Task<IEnumerable<UtilisateurApplication>> ChargerAll(int IdApplication)
        {
            throw new NotImplementedException();
        }

        public async Task<UtilisateurApplication> Recherche(string NomUtilisateur)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ModifierAccesRole(int IdApplication, int IdUtilisateur, int IdRole)
        {
            throw new NotImplementedException();
        }
    }
}



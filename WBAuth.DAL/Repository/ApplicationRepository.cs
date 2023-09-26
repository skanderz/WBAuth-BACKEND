using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;




namespace WBAuth.DAL.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public ApplicationRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }



        public async Task<IEnumerable<Application>> ChargerAll() { return await _dataContext.Set<Application>().ToListAsync(); }



        public async Task<int> Ajouter(Application oApplication)
        {
            if (oApplication == null) throw new ArgumentNullException(nameof(oApplication));
            _dataContext.Entry(oApplication).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oApplication.Id;
        }

        public async Task<int> Modifier(Application oApplication)
        {
            if (oApplication == null) throw new ArgumentNullException(nameof(oApplication));
            var entity = await _dataContext.Set<Application>().FirstOrDefaultAsync(item => item.Id == oApplication.Id);
            entity.Nom = oApplication.Nom;
            entity.Description = oApplication.Description;
            entity.Url = oApplication.Url;
            entity.Logo = oApplication.Logo;
            _dataContext.Entry<Application>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oApplication.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Application>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<Application>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<Application>> Recherche(string rech)
        {
            return await _dataContext.Set<Application>().Where(a => a.Nom == rech || a.Url == rech).ToListAsync();
        }


        public async Task<Application> RechercheById(int Id)
        {
            var oApplication = await _dataContext.Set<Application>().FirstOrDefaultAsync(a => a.Id == Id);
            if (oApplication == null) throw new ArgumentNullException(nameof(oApplication));
            return oApplication;
        }



    }
}



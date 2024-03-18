using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using UtilisateurApplication = WBAuth.DAL.Models.UtilisateurApplication;



namespace WBAuth.DAL.Repository
{
    public class UtilisateurApplicationRepository : IUtilisateurApplicationRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public UtilisateurApplicationRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }


        public async Task<int> Ajouter(UtilisateurApplication oUA)
        {
            if (oUA == null) throw new ArgumentNullException(nameof(oUA));
            _dataContext.Entry(oUA).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oUA.Id;
        }

        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication)
        {
            var userlist = await _dataContext.Set<UtilisateurApplication>().Where(ua => ua.IdApplication == IdApplication).ToArrayAsync();
            if (userlist == null) throw new ArgumentNullException(nameof(userlist));
            return userlist;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(string IdU)
        {
            var userlist = await _dataContext.Set<UtilisateurApplication>().Where(ua => ua.GuidUtilisateur == IdU).ToArrayAsync();
            if (userlist == null) throw new ArgumentNullException(nameof(userlist));
            return userlist;
        }


        public async Task<UtilisateurApplication> Recherche(int Id)
        {
            var userapp = await _dataContext.Set<UtilisateurApplication>().FirstOrDefaultAsync(ua => ua.Id == Id);
            if (userapp == null) throw new ArgumentNullException(nameof(userapp));
            return userapp;
        }


        public async Task<int> ModifierAccesRole(UtilisateurApplication oUA)
        {
            if (oUA == null) throw new ArgumentNullException(nameof(oUA));
            var entity = await _dataContext.Set<UtilisateurApplication>().FirstOrDefaultAsync(ua => ua.Id == oUA.Id);
            entity.Acces = oUA.Acces;
            entity.IdRole = oUA.IdRole;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }









    }
}



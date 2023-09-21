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



        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication)
        {
            var userlist = await _dataContext.Set<UtilisateurApplication>().Where(ua => ua.IdApplication == IdApplication && ua.Acces == true).ToArrayAsync();
            if (userlist == null) throw new ArgumentNullException(nameof(userlist));
            return userlist;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(int IdUtilisateur)
        {
            var userlist = await _dataContext.Set<UtilisateurApplication>().Where(ua => ua.IdUtilisateur == IdUtilisateur).ToArrayAsync();
            if (userlist == null) throw new ArgumentNullException(nameof(userlist));
            return userlist;
        }


        public async Task<UtilisateurApplication> Recherche(int IdUtilisateur, int IdApplication)
        {
            var user = await _dataContext.Set<UtilisateurApplication>().Where(ua => ua.IdApplication == IdApplication && ua.Acces == true).FirstOrDefaultAsync(ua => ua.IdUtilisateur == IdUtilisateur);
            if (user == null) throw new ArgumentNullException(nameof(user));
            return user;
        }


        public async Task<int> ModifierAccesRole(int IdUtilisateur, bool Acces, string NomRole)
        {
            var entity = await _dataContext.Set<UtilisateurApplication>().FirstOrDefaultAsync(ua => ua.IdUtilisateur == IdUtilisateur);
            if (entity != null) throw new ArgumentNullException(nameof(entity));
            entity.Acces = Acces;
            entity.Role.Nom = NomRole;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return entity.Id;
        }









    }
}



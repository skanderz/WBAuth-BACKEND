using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Permission = WBAuth.DAL.Models.Permission;



namespace WBAuth.DAL.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public PermissionRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }



        public async Task<IEnumerable<Permission>> ChargerAll() { return await _dataContext.Set<Permission>().ToListAsync(); }



        public async Task<int> Ajouter(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            _dataContext.Entry(oPermission).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oPermission.Id;
        }

        public async  Task<int> Modifier(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(item => item.Id == oPermission.Id);
            entity.Nom = oPermission.Nom;
            entity.Description = oPermission.Description;
            entity.Url = oPermission.Url;
            entity.Logo = oPermission.Logo;
            _dataContext.Entry<Permission>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oPermission.Id;
        }


        public async Task<bool> Suprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<Permission>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Permission> Recherche(int Id)
        {
            return await _dataContext.Set<Permission>().FirstOrDefaultAsync(item => item.Id == Id);
        }

        public Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> RechercheMultiFonction(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> RechercheFonctionUnique(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<int> ModifierAcces(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Suprimer(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }
    }
}



using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Role = WBAuth.DAL.Models.Role;



namespace WBAuth.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public RoleRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }



        public async Task<IEnumerable<Role>> ChargerAll() { return await _dataContext.Set<Role>().ToListAsync(); }



        public async Task<int> Ajouter(Role oRole)
        {
            if (oRole == null) throw new ArgumentNullException(nameof(oRole));
            _dataContext.Entry(oRole).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oRole.Id;
        }

        public async  Task<int> Modifier(Role oRole)
        {
            if (oRole == null) throw new ArgumentNullException(nameof(oRole));
            var entity = await _dataContext.Set<Role>().FirstOrDefaultAsync(item => item.Id == oRole.Id);
            entity.Nom = oRole.Nom;
            entity.Description = oRole.Description;
            entity.Url = oRole.Url;
            entity.Logo = oRole.Logo;
            _dataContext.Entry<Role>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oRole.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Role>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<Role>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Role> Recherche(int Id)
        {
            return await _dataContext.Set<Role>().FirstOrDefaultAsync(item => item.Id == Id);
        }

        public Task<IEnumerable<Role>> ChargerAll(int idApplication)
        {
            throw new NotImplementedException();
        }
    }
}



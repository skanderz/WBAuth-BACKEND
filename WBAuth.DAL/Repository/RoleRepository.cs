using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Role = WBAuth.DAL.Models.Role;



namespace WBAuth.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public RoleRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }



        public async Task<IEnumerable<Role>> ChargerAll(int idApplication)
        {
            var role = await _dataContext.Set<Role>().Where(r => r.IdApplication == idApplication).ToListAsync();
            if (role == null) throw new ArgumentNullException("Liste Introuvable");
            return role;
        }


        public async Task<IEnumerable<Role>> Recherche(string rech, int IdApplication)
        {
            var application = await _dataContext.Application.FindAsync(IdApplication);
            var role = await _dataContext.Set<Role>().Where(f => f.IdApplication == IdApplication && f.Nom == rech).ToListAsync();
            if (application == null) throw new InvalidOperationException("L'application spécifiée n'a pas été trouvée.");
            if (role == null) throw new InvalidOperationException("La role spécifiée n'a pas été trouvée.");
            return role;
        }


        public async Task<Role> RechercheById(int Id)
        {
            var role = await _dataContext.Set<Role>().FirstOrDefaultAsync(r => r.Id == Id);
            if (role == null) throw new InvalidOperationException("La role spécifiée n'a pas été trouvée.");
            return role;
        }


        public async Task<int> Ajouter(Role oRole)
        {
            if (oRole == null) throw new ArgumentNullException(nameof(oRole));
            _dataContext.Entry(oRole).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oRole.Id;
        }


        public async Task<int> Modifier(Role oRole)
        {
            if (oRole == null) throw new ArgumentNullException(nameof(oRole));
            var entity = await _dataContext.Set<Role>().FirstOrDefaultAsync(item => item.Id == oRole.Id);
            entity.Nom = oRole.Nom;
            entity.Niveau = oRole.Niveau;
            entity.Description = oRole.Description;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oRole.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            var entity = await _dataContext.Set<Role>().FirstOrDefaultAsync(item => item.Id == Id);
            if (entity == null) throw new ArgumentNullException("Objet introuvable");
            _dataContext.Entry(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }









    }
}



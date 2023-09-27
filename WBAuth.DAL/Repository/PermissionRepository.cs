using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Permission = WBAuth.DAL.Models.Permission;

namespace WBAuth.DAL.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public PermissionRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }



        public async Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "unique").ToListAsync();
            return permissions;
        }


        public async Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "multi").ToListAsync();
            if (permissions == null) throw new ArgumentNullException("Liste introuvable");
            return permissions;
        }


        public async Task<Permission> RechercheFonctionUniqueById(int Id, int IdApplication, int IdRole)
        {
            var permission = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "unique")
                                                                 .FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            return permission;
        }


        public async Task<Permission> RechercheMultiFonctionById(int Id, int IdApplication, int IdRole)
        {
            var permission = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "multi")
                                                                 .FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            return permission;
        }


        public async Task<IEnumerable<Permission>> RechercheFonctionUnique(string rech, int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>()
            .Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "unique" && p.Nom == rech).ToListAsync();
            if (permissions == null) throw new ArgumentNullException(nameof(permissions));
            return permissions;
        }


        public async Task<IEnumerable<Permission>> RechercheMultiFonction(string rech, int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>()
            .Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "multi" && p.Nom == rech).ToListAsync();
            if (permissions == null) throw new ArgumentNullException(nameof(permissions));
            return permissions;
        }


        public async Task<int> Ajouter(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            _dataContext.Entry(oPermission).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oPermission.Id;
        }


        public async Task<int> Modifier(Permission oPermission, string type)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == oPermission.Id);
            entity.Nom = oPermission.Nom;
            _dataContext.Entry(entity).State = EntityState.Modified;

            var entityf = await _dataContext.Set<Fonction>().FirstOrDefaultAsync(f => f.Id == oPermission.IdFonction);
            if (entityf == null) throw new ArgumentNullException(nameof(entityf));
            if (type == "unique" || type == "multi") entityf.Type = type; else throw new ArgumentException("type non reconnu", nameof(type));
            _dataContext.Entry(entityf).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oPermission.Id;
        }


        public async Task<int> ModifierAcces(int Id, int IdApplication, int IdRole, int i)
        {
            var permission = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication).FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            if (permission.Fonction.Type == "unique") { if (permission.Status != 1) permission.Status = 1; else permission.Status = 0; }
            if (permission.Fonction.Type == "multi")
            {
                string p = permission.Status.ToString();
                switch (i)
                {
                    case 1: if (p[i - 1] == '1') permission.Status -= 1; else permission.Status += 1; break;
                    case 2: if (p[i - 1] == '1') permission.Status -= 10; else permission.Status += 10; break;
                    case 3: if (p[i - 1] == '1') permission.Status -= 100; else permission.Status += 100; break;
                    case 4: if (p[i - 1] == '1') permission.Status -= 1000; else permission.Status += 1000; break;
                    case 5: if (p[i - 1] == '1') permission.Status -= 10000; else permission.Status += 10000; break;
                    case 6: if (p[i - 1] == '1') permission.Status -= 100000; else permission.Status += 100000; break;
                    default: Console.WriteLine("erreur technique ou la permission ne correspond à aucune case "); break;
                }
            }
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == Id);
            if (entity != null) throw new ArgumentNullException(nameof(entity));
            entity.Status = permission.Status;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return permission.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(item => item.Id == Id);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dataContext.Entry(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }






    }
}



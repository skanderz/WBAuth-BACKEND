using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            var permissions = await _dataContext.Set<Permission>()
            .Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "Fonction Unique").ToListAsync();
            if (permissions == null) throw new ArgumentNullException("Liste de permission introuvable");
            return permissions;
        }


        public async Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>()
            .Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "Multifonctions").ToListAsync();
            if (permissions == null) throw new ArgumentNullException("Liste de permission introuvable");
            return permissions;
        }


        public async Task<Permission> RechercheFonctionUniqueById(int Id)
        {
            var permission = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            return permission;
        }


        public async Task<Permission> RechercheMultiFonctionById(int Id)
        {
            var permission = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            return permission;
        }

        

        public async Task<int> Ajouter(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            _dataContext.Entry(oPermission).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oPermission.Id;
        }


        public async Task<int> Modifier(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == oPermission.Id);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entity.Nom = oPermission.Nom;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oPermission.Id;
        }


        public async Task<int> ModifierAcces(int Id, int i)
        {
            var permission = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            var fonction = await _dataContext.Set<Fonction>().FirstOrDefaultAsync(f => f.Id == permission.IdFonction);
            if (fonction.Type == "Fonction Unique") { if (permission.Status != "1") { permission.Status = "1"; }  else { permission.Status = "0"; } }
            if (fonction.Type == "Multifonctions")
            {
                char[] p = permission.Status.ToCharArray();
                switch (i)
               {
                  case 0: if (p[i] == '1') p[i] = '0'; else p[i] = '1'; break;
                  case 1: if (p[i] == '1') p[i] = '0'; else p[i] = '1'; break;
                  case 2: if (p[i] == '1') p[i] = '0'; else p[i] = '1'; break;
                  case 3: if (p[i] == '1') p[i] = '0'; else p[i] = '1'; break;
                  case 4: if (p[i] == '1') p[i] = '0'; else p[i] = '1'; break;
                  case 5: if (p[i] == '1') p[i] = '0'; else p[i] = '1'; break;
                  default: Console.WriteLine("erreur technique ou la permission ne correspond à aucune case "); break;
               }
                permission.Status = new string(p);
            }
            var entity = await _dataContext.Set<Permission>().FirstOrDefaultAsync(p => p.Id == Id);
            if (entity == null) throw new ArgumentNullException(nameof(entity));
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



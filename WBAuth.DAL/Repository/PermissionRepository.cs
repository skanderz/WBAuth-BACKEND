using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Permission = WBAuth.DAL.Models.Permission;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security;

namespace WBAuth.DAL.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public PermissionRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }



        public async Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "unique").ToListAsync();
            return permissions;
        }


        public async Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            var permissions = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "multi").ToListAsync();
            if(permissions == null) throw new ArgumentNullException("Liste introuvable");
            return permissions;
        }


        public async Task<Permission> RechercheFonctionUnique(int Id, int IdApplication, int IdRole)
        {
            var permission = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "unique")
                                                                 .FirstOrDefaultAsync(p => p.Id == Id);
            if(permission == null) throw new ArgumentNullException(nameof(permission));
            return permission;
        }


        public async Task<Permission> RechercheMultiFonction(int Id, int IdApplication, int IdRole)
        {
            var permission = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication && p.Fonction.Type == "multi")
                                                                 .FirstOrDefaultAsync(p => p.Id == Id);
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


        public async Task<int> Modifier(Permission oPermission ,string type)
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


        public async Task<int> ModifierAcces(int Id, int IdApplication, int IdRole ,int i)
        {
            var permission = await _dataContext.Set<Permission>().Where(p => p.IdRole == IdRole && p.Fonction.IdApplication == IdApplication ).FirstOrDefaultAsync(p => p.Id == Id);
            if (permission == null) throw new ArgumentNullException(nameof(permission));
            if (permission.Fonction.Type == "unique"){   if(permission.Status != "1") permission.Status = "1";  else permission.Status = "0";   }
            if (permission.Fonction.Type == "multi"){
                switch (i){
                    case 1: char x = permission.Status[0];  break;
                    case 2:  break;
                    case 3:  break;
                    case 4:  break;
                    case 5:  break;
                    case 6:  break;
                    default: Console.WriteLine("la permission ne correspond à aucune case ou erreur technique");  break;
                }
            }
            return permission.Id;
        }


        public async Task<bool> Supprimer(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }





    }
}



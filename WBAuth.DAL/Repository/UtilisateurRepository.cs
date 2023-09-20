using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Utilisateur = WBAuth.DAL.Models.Utilisateur;



namespace WBAuth.DAL.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public UtilisateurRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }



        public async Task<IEnumerable<Utilisateur>> ChargerAll() { return await _dataContext.Set<Utilisateur>().ToListAsync(); }



        public async Task<int> Ajouter(Utilisateur oUtilisateur)
        {
            if (oUtilisateur == null) throw new ArgumentNullException(nameof(oUtilisateur));
            _dataContext.Entry(oUtilisateur).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oUtilisateur.Id;
        }

        public async  Task<int> Modifier(Utilisateur oUtilisateur)
        {
            if (oUtilisateur == null) throw new ArgumentNullException(nameof(oUtilisateur));
            var entity = await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(item => item.Id == oUtilisateur.Id);
            entity.Nom = oUtilisateur.Nom;
            entity.Description = oUtilisateur.Description;
            entity.Url = oUtilisateur.Url;
            entity.Logo = oUtilisateur.Logo;
            _dataContext.Entry<Utilisateur>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oUtilisateur.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<Utilisateur>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Utilisateur> Recherche(int Id)
        {
            return await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(item => item.Id == Id);
        }


    }
}



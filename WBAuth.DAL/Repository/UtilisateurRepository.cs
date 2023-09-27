using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Utilisateur = WBAuth.DAL.Models.Utilisateur;



namespace WBAuth.DAL.Repository
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public UtilisateurRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }



        public async Task<IEnumerable<Utilisateur>> ChargerAll() { return await _dataContext.Set<Utilisateur>().ToListAsync(); }



        public async Task<int> Ajouter(Utilisateur oUtilisateur)
        {
            if (oUtilisateur == null) throw new ArgumentNullException(nameof(oUtilisateur));
            _dataContext.Entry(oUtilisateur).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oUtilisateur.Id;
        }


        public async Task<int> Modifier(Utilisateur oUtilisateur)
        {
            if (oUtilisateur == null) throw new ArgumentNullException(nameof(oUtilisateur));
            var entity = await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(u => u.Id == oUtilisateur.Id);
            entity.Email = oUtilisateur.Email;
            entity.Status = oUtilisateur.Status;
            entity.Nom = oUtilisateur.Nom;
            entity.Prenom = oUtilisateur.Prenom;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oUtilisateur.Id;
        }


        public async Task<bool> Supprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(u => u.Id == Id);
            _dataContext.Entry<Utilisateur>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Utilisateur> RechercheById(int Id)
        {
            var oUser = await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(u => u.Id == Id);
            if (oUser == null) throw new ArgumentNullException(nameof(oUser));
            return oUser;
        }


        public async Task<IEnumerable<Utilisateur>> Recherche(string rech)
        {
            var Users = await _dataContext.Set<Utilisateur>().Where(u => u.NomUtilisateur == rech || u.Email == rech || u.Nom == rech || u.Prenom == rech).ToListAsync();
            if (Users == null) throw new ArgumentNullException(nameof(Users));
            return Users;
        }




    }
}



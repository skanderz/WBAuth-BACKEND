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



        public async Task<IEnumerable<Utilisateur>> ChargerAll() { 
            return await _dataContext.Set<Utilisateur>().ToListAsync(); 
        }


        public async Task<Utilisateur> RechercheById(string Id)
        {
            var oUser = await _dataContext.Set<Utilisateur>().FirstOrDefaultAsync(u => u.Id == Id);
            if (oUser == null) throw new ArgumentNullException(nameof(oUser));
            return oUser;
        }


        public async Task<IEnumerable<Utilisateur>> Recherche(string rech)
        {
            var Users = await _dataContext.Set<Utilisateur>().Where(u => u.UserName == rech || u.Email == rech || u.Nom == rech || u.Prenom == rech).ToListAsync();
            if (Users == null) throw new ArgumentNullException(nameof(Users));
            return Users;
        }


    }
}



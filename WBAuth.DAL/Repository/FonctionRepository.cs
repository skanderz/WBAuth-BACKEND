using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Fonction = WBAuth.DAL.Models.Fonction;



namespace WBAuth.DAL.Repository
{
    public class FonctionRepository : IFonctionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public FonctionRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }


        public Task<IEnumerable<Fonction>> ChargerAll(int IdApplication)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Fonction>> ChargerAll() { return await _dataContext.Set<Fonction>().ToListAsync(); }



        public async Task<int> Ajouter(Fonction oFonction)
        {
            if (oFonction == null) throw new ArgumentNullException(nameof(oFonction));
            _dataContext.Entry(oFonction).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oFonction.Id;
        }

        public async  Task<int> Modifier(Fonction oFonction)
        {
            if (oFonction == null) throw new ArgumentNullException(nameof(oFonction));
            var entity = await _dataContext.Set<Fonction>().FirstOrDefaultAsync(item => item.Id == oFonction.Id);
            entity.Nom = oFonction.Nom;
            entity.Description = oFonction.Description;
            entity.Url = oFonction.Url;
            entity.Logo = oFonction.Logo;
            _dataContext.Entry<Fonction>(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oFonction.Id;
        }


        public async Task<bool> Suprimer(int Id)
        {
            if (Id < 0) throw new ArgumentNullException(nameof(Id));
            var entity = await _dataContext.Set<Fonction>().FirstOrDefaultAsync(item => item.Id == Id);
            _dataContext.Entry<Fonction>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<Fonction> Recherche(int Id)
        {
            return await _dataContext.Set<Fonction>().FirstOrDefaultAsync(item => item.Id == Id);
        }

 




    }
}



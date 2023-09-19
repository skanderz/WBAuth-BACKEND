using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Fonction = WBAuth.DAL.Models.Fonction;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WBAuth.DAL.Repository
{
    public class FonctionRepository : IFonctionRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public FonctionRepository(ApplicationDbContext dataContext){ _dataContext = dataContext; }



        public async Task<IEnumerable<Fonction>> ChargerAll(int IdApplication)
        {
            var application = await _dataContext.Application.FindAsync(IdApplication);
            if (application == null) throw new InvalidOperationException("L'application spécifiée n'a pas été trouvée.");
            return await _dataContext.Set<Fonction>().Where(f => f.IdApplication == IdApplication).ToListAsync();
        }


        public async Task<Fonction> Recherche(int Id, int IdApplication)
        {
            var application = await _dataContext.Application.FindAsync(IdApplication);
            var fonction = await _dataContext.Set<Fonction>().Where(f => f.IdApplication == IdApplication).FirstOrDefaultAsync(f => f.Id == Id);
            if (application == null ) throw new InvalidOperationException("L'application spécifiée n'a pas été trouvée.");
            if (fonction == null) throw new InvalidOperationException("La fonction spécifiée n'a pas été trouvée.");
            return fonction;
        }


        public async Task<int> Ajouter(Fonction oFonction, int IdApplication)
        {
            if (oFonction == null) throw new ArgumentNullException(nameof(oFonction)); 
            var application = await _dataContext.Application.FindAsync(IdApplication);

            if (application == null) throw new InvalidOperationException("L'application spécifiée n'a pas été trouvée.");  
            application.Fonctions.Add(oFonction);

            _dataContext.Entry(oFonction).State = EntityState.Added;
            await _dataContext.SaveChangesAsync();
            return oFonction.Id;
        }



        public async Task<int> Modifier(Fonction oFonction, int IdApplication)
        {
            if (oFonction.Nom == null) throw new InvalidOperationException("Le champ 'Nom' ne peut pas être null.");
            var application = await _dataContext.Application.FindAsync(IdApplication);
            if (application == null) throw new InvalidOperationException("L'application spécifiée n'a pas été trouvée.");

            var entity = await _dataContext.Set<Fonction>().Where(f => f.IdApplication == IdApplication).FirstOrDefaultAsync(f => f.Id == oFonction.Id);
            entity.Nom = oFonction.Nom; 
            entity.Description = oFonction.Description;
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return oFonction.Id;
        }


        public async Task<bool> Suprimer(int Id, int IdApplication)
        {
            var entity = await _dataContext.Set<Fonction>().Where(f => f.IdApplication == IdApplication).FirstOrDefaultAsync(f => f.Id == Id);
            if(entity == null) throw new InvalidOperationException("La fonction spécifiée n'a pas été trouvée.");
            _dataContext.Entry<Fonction>(entity).State = EntityState.Deleted;
            await _dataContext.SaveChangesAsync();
            return true;
        }


     
 




    }
}



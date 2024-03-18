using Microsoft.EntityFrameworkCore;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Models;
using Utilisateur = WBAuth.DAL.Models.Utilisateur;



namespace WBAuth.DAL.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _dataContext;
        public ServiceRepository(ApplicationDbContext dataContext) { _dataContext = dataContext; }





    }
}



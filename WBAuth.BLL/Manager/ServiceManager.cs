using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUtilisateurRepository _IUtilisateurRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<DAL.Models.Utilisateur> _userManager;


        public ServiceManager(UserManager<DAL.Models.Utilisateur> userManager, IUtilisateurRepository IUtilisateurRepository, IMapper mapper)
        {
            _IUtilisateurRepository = IUtilisateurRepository;
            _mapper = mapper;
            _userManager = userManager;
        }





    }
}

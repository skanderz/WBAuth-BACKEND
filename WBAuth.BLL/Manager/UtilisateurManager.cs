using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class UtilisateurManager : IUtilisateurManager
    {
        private readonly IUtilisateurRepository _IUtilisateurRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<DAL.Models.Utilisateur> _userManager;


        public UtilisateurManager(UserManager<DAL.Models.Utilisateur> userManager ,IUtilisateurRepository IUtilisateurRepository, IMapper mapper)
        {
            _IUtilisateurRepository = IUtilisateurRepository;
            _mapper = mapper;
            _userManager = userManager;
        }



        public async Task<IEnumerable<Utilisateur>> ChargerAll()
        {
            var Utilisateurs = await _IUtilisateurRepository.ChargerAll();
            var model = _mapper.Map<List<Utilisateur>>(Utilisateurs);
            return model;
        }


        public async Task<IEnumerable<Utilisateur>> Recherche(string rech)
        {
            var Utilisateurs = await _IUtilisateurRepository.Recherche(rech);
            var models = _mapper.Map<List<Utilisateur>>(Utilisateurs);
            return models;
        }

        public async Task<Utilisateur> RechercheById(string Id)
        {
            var oUtilisateur = await _IUtilisateurRepository.RechercheById(Id);
            var model = _mapper.Map<Utilisateur>(oUtilisateur);
            return model;
        }




    }
}

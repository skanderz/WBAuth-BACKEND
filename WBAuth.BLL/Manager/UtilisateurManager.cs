using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class UtilisateurManager : IUtilisateurManager
    {
        private readonly IUtilisateurRepository _IUtilisateurRepository;
        private readonly IMapper _mapper;

        public UtilisateurManager(IUtilisateurRepository IUtilisateurRepository, IMapper mapper)
        {
            _IUtilisateurRepository = IUtilisateurRepository;
            _mapper = mapper;
        }


        public async Task<int> Ajouter(Utilisateur oUtilisateur)
        {
            if (oUtilisateur == null) throw new ArgumentNullException(nameof(oUtilisateur));
            var entity = _mapper.Map<DAL.Models.Utilisateur>(oUtilisateur);
            var id = await _IUtilisateurRepository.Ajouter(entity);
            return id;
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

        public async Task<Utilisateur> RechercheById(int Id)
        {
            var oUtilisateur = await _IUtilisateurRepository.RechercheById(Id);
            var model = _mapper.Map<Utilisateur>(oUtilisateur);
            return model;
        }


        public async Task<int> Modifier(Utilisateur oUtilisateur)
        {
            if (oUtilisateur == null) throw new ArgumentNullException(nameof(oUtilisateur));
            var entity = _mapper.Map<DAL.Models.Utilisateur>(oUtilisateur);
            var id = await _IUtilisateurRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Supprimer(int Id) { return await _IUtilisateurRepository.Supprimer(Id); }



    }
}

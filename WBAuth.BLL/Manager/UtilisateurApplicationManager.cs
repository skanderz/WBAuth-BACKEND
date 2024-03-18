using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class UtilisateurApplicationManager : IUtilisateurApplicationManager
    {
        private readonly IUtilisateurApplicationRepository _IUtilisateurApplicationRepository;
        private readonly IMapper _mapper;

        public UtilisateurApplicationManager(IUtilisateurApplicationRepository IUtilisateurApplicationRepository, IMapper mapper)
        {
            _IUtilisateurApplicationRepository = IUtilisateurApplicationRepository;
            _mapper = mapper;
        }


        public async Task<int> Ajouter(UtilisateurApplication oUA)
        {
            if (oUA == null) throw new ArgumentNullException(nameof(oUA));
            var entity = _mapper.Map<DAL.Models.UtilisateurApplication>(oUA);
            var id = await _IUtilisateurApplicationRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication)
        {
            var UtilisateurApplications = await _IUtilisateurApplicationRepository.ChargerAllByApplication(IdApplication);
            var model = _mapper.Map<List<UtilisateurApplication>>(UtilisateurApplications);
            return model;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(string GuidUtilisateur)
        {
            var UtilisateurApplications = await _IUtilisateurApplicationRepository.ChargerAllByUtilisateur(GuidUtilisateur);
            var model = _mapper.Map<List<UtilisateurApplication>>(UtilisateurApplications);
            return model;
        }


        public async Task<int> ModifierAccesRole(UtilisateurApplication oUA)
        {
            if (oUA == null) throw new ArgumentNullException(nameof(oUA));
            var entity = _mapper.Map<DAL.Models.UtilisateurApplication>(oUA);
            var id = await _IUtilisateurApplicationRepository.ModifierAccesRole(entity);
            return id;
        }


        public async Task<UtilisateurApplication> Recherche(int Id)
        {
            var oUtilisateurApplication = await _IUtilisateurApplicationRepository.Recherche(Id);
            var model = _mapper.Map<UtilisateurApplication>(oUtilisateurApplication);
            return model;
        }








    }
}

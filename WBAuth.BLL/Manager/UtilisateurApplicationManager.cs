using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class UtilisateurApplicationManager : IUtilisateurApplicationManager
    {
        private readonly IUtilisateurApplicationRepository _IUtilisateurApplicationRepository;
        private readonly IRoleRepository _IRoleRepository;
        private readonly IMapper _mapper;

        public UtilisateurApplicationManager(IUtilisateurApplicationRepository IUtilisateurApplicationRepository, IMapper mapper)
        {
            _IUtilisateurApplicationRepository = IUtilisateurApplicationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByApplication(int IdApplication)
        {
            var UtilisateurApplications = await _IUtilisateurApplicationRepository.ChargerAllByApplication(IdApplication);
            var model = _mapper.Map<List<UtilisateurApplication>>(UtilisateurApplications);
            return model;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAllByUtilisateur(int IdUtilisateur)
        {
            var UtilisateurApplications = await _IUtilisateurApplicationRepository.ChargerAllByUtilisateur(IdUtilisateur);
            var model = _mapper.Map<List<UtilisateurApplication>>(UtilisateurApplications);
            return model;
        }


        public async Task<int> ModifierAccesRole(int IdUtilisateur, int IdApplication, bool Acces, string NomRole)
        {
            var id = await _IUtilisateurApplicationRepository.ModifierAccesRole(IdUtilisateur, IdApplication, Acces, NomRole);
            return id;
        }


        public async Task<UtilisateurApplication> Recherche(int IdUtilisateur, int IdApplication)
        {
            var oUtilisateurApplication = await _IUtilisateurApplicationRepository.Recherche(rechApplication, IdApplication);
            var model = _mapper.Map<UtilisateurApplication>(oUtilisateurApplication);
            return model;
        }








    }
}

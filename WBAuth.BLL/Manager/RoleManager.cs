using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository _IRoleRepository;
        private readonly IMapper _mapper;

        public RoleManager(IRoleRepository IRoleRepository, IMapper mapper)
        {
            _IRoleRepository = IRoleRepository;
            _mapper = mapper;
        }


        public async Task<int> Ajouter(Role oRole)
        {
            if (oRole == null) throw new ArgumentNullException(nameof(oRole));
            var entity = _mapper.Map<DAL.Models.Role>(oRole);
            var id = await _IRoleRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<Role>> ChargerAll(int IdApplication)
        {
            var Roles = await _IRoleRepository.ChargerAll(IdApplication);
            var model = _mapper.Map<List<Role>>(Roles);
            return model;
        }


        public async Task<IEnumerable<Role>> Recherche(string rech ,int IdApplication)
        {
            var Roles = await _IRoleRepository.Recherche(rech, IdApplication);
            var models = _mapper.Map<List<Role>>(Roles);
            return models;
        }

        public async Task<Role> RechercheById(int Id)
        {
            var oRole = await _IRoleRepository.RechercheById(Id);
            var model = _mapper.Map<Role>(oRole);
            return model;
        }


        public async Task<int> Modifier(Role oRole)
        {
            if (oRole == null) throw new ArgumentNullException(nameof(oRole));
            var entity = _mapper.Map<DAL.Models.Role>(oRole);
            var id = await _IRoleRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Supprimer(int Id) { return await _IRoleRepository.Supprimer(Id); }



    }
}

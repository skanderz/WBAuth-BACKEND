using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


namespace WBAuth.BLL.Manager
{
    public class RoleManagerDAO : IRoleManagerDAO
    {
        private readonly IRoleRepositoryDAO _IRoleRepository;
        private readonly IMapper _mapper;

        public RoleManagerDAO(IRoleRepositoryDAO IRoleRepository, IMapper mapper)
        {
            _IRoleRepository = IRoleRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Role>> ChargerAll(int IdApplication)
        {
            var Roles = await _IRoleRepository.ChargerAll(IdApplication);
            var model = _mapper.Map<List<Role>>(Roles);
            return model;
        }

        public Task<IEnumerable<Role>> ChargerAll()
        {
            throw new NotImplementedException();
        }
    }
}



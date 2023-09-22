using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


namespace WBAuth.BLL.Manager
{
    public class PermissionManagerDAO : IPermissionManagerDAO
    {
        private readonly IPermissionRepositoryDAO _IPermissionRepository;
        private readonly IMapper _mapper;

        public PermissionManagerDAO(IPermissionRepositoryDAO IPermissionRepository, IMapper mapper)
        {
            _IPermissionRepository = IPermissionRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<Permission>> ChargerAll()
        {
            throw new NotImplementedException();
        }




    }
}



using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


namespace WBAuth.BLL.Manager
{
    public class ApplicationManagerDAO : IApplicationManagerDAO
    {
        private readonly IApplicationRepositoryDAO _IApplicationRepository;
        private readonly IMapper _mapper;

        public ApplicationManagerDAO(IApplicationRepositoryDAO IApplicationRepository, IMapper mapper)
        {
            _IApplicationRepository = IApplicationRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Application>> ChargerAll()
        {
            var Applications = await _IApplicationRepository.ChargerAll();
            var model = _mapper.Map<List<Application>>(Applications);
            return model;
        }
    }
}



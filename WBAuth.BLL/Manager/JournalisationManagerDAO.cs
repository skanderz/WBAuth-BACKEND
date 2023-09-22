using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


namespace WBAuth.BLL.Manager
{
    public class JournalisationManagerDAO : IJournalisationManagerDAO
    {
        private readonly IJournalisationRepositoryDAO _IJournalisationRepository;
        private readonly IMapper _mapper;

        public JournalisationManagerDAO(IJournalisationRepositoryDAO IJournalisationRepository, IMapper mapper)
        {
            _IJournalisationRepository = IJournalisationRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<Journalisation>> ChargerAll()
        {
            throw new NotImplementedException();
        }
    }
}



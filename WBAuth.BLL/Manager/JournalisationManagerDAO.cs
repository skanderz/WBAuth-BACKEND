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


        public async Task<IEnumerable<Journalisation>> ChargerAll()
        {
            var Journalisations = await _IJournalisationRepository.ChargerAll();
            var model = _mapper.Map<List<Journalisation>>(Journalisations);
            return model;
        }
    }
}



using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


namespace WBAuth.BLL.Manager
{
    public class ActionManagerDAO : IActionManagerDAO
    {
        private readonly IActionRepositoryDAO _IActionRepository;
        private readonly IMapper _mapper;

        public ActionManagerDAO(IActionRepositoryDAO IActionRepository, IMapper mapper)
        {
            _IActionRepository = IActionRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Action>> ChargerAll()
        {
            var Actions = await _IActionRepository.ChargerAll();
            var model = _mapper.Map<List<Action>>(Actions);
            return model;
        }
    }
}



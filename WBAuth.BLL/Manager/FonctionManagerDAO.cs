using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


namespace WBAuth.BLL.Manager
{
    public class FonctionManagerDAO : IFonctionManagerDAO
    {
        private readonly IFonctionRepositoryDAO _IFonctionRepository;
        private readonly IMapper _mapper;

        public FonctionManagerDAO(IFonctionRepositoryDAO IFonctionRepository, IMapper mapper)
        {
            _IFonctionRepository = IFonctionRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Fonction>> ChargerAll(int IdApplication)
        {
            var Fonctions = await _IFonctionRepository.ChargerAll(IdApplication);
            var model = _mapper.Map<List<Fonction>>(Fonctions);
            return model;
        }

        public Task<IEnumerable<Fonction>> ChargerAll()
        {
            throw new NotImplementedException();
        }




    }
}



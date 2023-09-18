using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;


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


        public async Task<IEnumerable<Fonction>> ChargerAll()
        {
            var Fonctions = await _IFonctionRepository.ChargerAll();
            var model = _mapper.Map<List<Fonction>>(Fonctions);
            return model;
        }
    }
}



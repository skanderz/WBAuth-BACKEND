using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;



namespace WBAuth.BLL.Manager
{
    public class FonctionManager : IFonctionManager
    {
        private readonly IFonctionRepository _IFonctionRepository;
        private readonly IMapper _mapper;

        public FonctionManager(IFonctionRepository IFonctionRepository, IMapper mapper)
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


        public async Task<IEnumerable<Fonction>> Recherche(string rech, int IdApplication)
        {
            var oFonction = await _IFonctionRepository.Recherche(rech, IdApplication);
            var model = _mapper.Map<List<Fonction>>(oFonction);
            return model;
        }


        public async Task<Fonction> RechercheById(int Id, int IdApplication)
        {
            var oFonction = await _IFonctionRepository.RechercheById(Id, IdApplication);
            var model = _mapper.Map<Fonction>(oFonction);
            return model;
        }


        public async Task<int> Ajouter(Fonction oFonction, int IdApplication)
        {
            var entity = _mapper.Map<DAL.Models.Fonction>(oFonction);
            var id = await _IFonctionRepository.Ajouter(entity, IdApplication);
            return id;
        }



        public async Task<int> Modifier(Fonction oFonction, int IdApplication)
        {
            var entity = _mapper.Map<DAL.Models.Fonction>(oFonction);
            var id = await _IFonctionRepository.Modifier(entity, IdApplication);
            return id;
        }


        public async Task<bool> Supprimer(int Id, int IdApplication) { return await _IFonctionRepository.Supprimer(Id, IdApplication); }




    }
}

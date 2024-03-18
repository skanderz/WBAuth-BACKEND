using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Repository;
using Action = WBAuth.BO.Action;



namespace WBAuth.BLL.Manager
{
    public class ActionManager : IActionManager
    {
        private readonly IActionRepository _IActionRepository;
        private readonly IMapper _mapper;

        public ActionManager(IActionRepository IActionRepository, IMapper mapper)
        {
            _IActionRepository = IActionRepository;
            _mapper = mapper;
        }



        public async Task<IEnumerable<Action>> ChargerListe(int IdJournalisation)
        {
            var Actions = await _IActionRepository.ChargerListe(IdJournalisation);
            if (Actions == null) throw new ArgumentNullException(nameof(Actions));
            var model = _mapper.Map<List<Action>>(Actions);
            return model;
        }


        public async Task<Action> RechercheById(int Id)
        {
            var oAction = await _IActionRepository.RechercheById(Id);
            if (oAction == null) throw new ArgumentNullException(nameof(oAction));
            var model = _mapper.Map<Action>(oAction);
            return model;
        }


        public async Task<IEnumerable<Action>> Recherche(string rech)
        {
            var Actions = await _IActionRepository.Recherche(rech);
            if (Actions == null) throw new ArgumentNullException(nameof(Actions));
            var models = _mapper.Map<List<Action>>(Actions);
            return models;
        }


        public async Task<int> EnregistrementActions(Action oAction)
        {
            if (oAction == null) throw new ArgumentNullException(nameof(oAction));
            var entity = _mapper.Map<DAL.Models.Action>(oAction);
            var id = await _IActionRepository.EnregistrementActions(entity);
            return id;
        }

        public async Task<bool> Clear(int Id) { return await _IActionRepository.Clear(Id); }








    }
}

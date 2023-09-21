using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.DAL.IRepository;
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


        public async Task<Action> Recherche(int Id)
        {
            var oAction = await _IActionRepository.Recherche(Id);
            if (oAction == null) throw new ArgumentNullException(nameof(oAction));
            var model = _mapper.Map<Action>(oAction);
            return model;
        }


        public Task<int> EnregistrementActions(int IdJournalisation)
        {
            // Saisir Await //
            throw new NotImplementedException();
        }

        public async Task<bool> Clear(int Id) { return await _IActionRepository.Clear(Id); }








    }
}

using WBAuth.DAL.IRepository;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



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


        public async Task<int> Ajouter(Action oAction)
        {
            if (oAction == null) throw new ArgumentNullException(nameof(oAction));
            var entity = _mapper.Map<DAL.Models.Action> (oAction);
            var id = await _IActionRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<Action>> ChargerAll()
        {
            var Actions = await _IActionRepository.ChargerAll();
            var model = _mapper.Map<List<Action>>(Actions);
            return model;
        }


        public async Task<Action> Recherche(int Id)
        {
            var oAction = await _IActionRepository.Recherche(Id);
            var model = _mapper.Map<Action>(oAction);
            return model;
        }


        public async Task<int> Modifier(Action oAction)
        {
            if (oAction == null) throw new ArgumentNullException(nameof(oAction));
            var entity = _mapper.Map<DAL.Models.Action>(oAction);
            var id = await _IActionRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Suprimer(int Id)   {   return await _IActionRepository.Suprimer(Id);     }



    }
}

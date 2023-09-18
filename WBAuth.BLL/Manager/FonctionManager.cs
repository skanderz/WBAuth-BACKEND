using WBAuth.DAL.IRepository;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



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


        public async Task<int> Ajouter(Fonction oFonction)
        {
            if (oFonction == null) throw new ArgumentNullException(nameof(oFonction));
            var entity = _mapper.Map<DAL.Models.Fonction> (oFonction);
            var id = await _IFonctionRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<Fonction>> ChargerAll()
        {
            var Fonctions = await _IFonctionRepository.ChargerAll();
            var model = _mapper.Map<List<Fonction>>(Fonctions);
            return model;
        }


        public async Task<Fonction> Recherche(int Id)
        {
            var oFonction = await _IFonctionRepository.Recherche(Id);
            var model = _mapper.Map<Fonction>(oFonction);
            return model;
        }


        public async Task<int> Modifier(Fonction oFonction)
        {
            if (oFonction == null) throw new ArgumentNullException(nameof(oFonction));
            var entity = _mapper.Map<DAL.Models.Fonction>(oFonction);
            var id = await _IFonctionRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Suprimer(int Id)   {   return await _IFonctionRepository.Suprimer(Id);     }



    }
}

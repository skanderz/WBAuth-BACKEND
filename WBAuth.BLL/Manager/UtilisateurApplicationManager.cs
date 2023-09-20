using WBAuth.DAL.IRepository;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace WBAuth.BLL.Manager
{
   public class UtilisateurApplicationManager : IUtilisateurApplicationManager
    {
        private readonly IUtilisateurApplicationRepository _IUtilisateurApplicationRepository;
        private readonly IMapper _mapper;

        public UtilisateurApplicationManager(IUtilisateurApplicationRepository IUtilisateurApplicationRepository, IMapper mapper)
        {
            _IUtilisateurApplicationRepository = IUtilisateurApplicationRepository;
            _mapper = mapper;
        }


        public async Task<int> Ajouter(UtilisateurApplication oUtilisateurApplication)
        {
            if (oUtilisateurApplication == null) throw new ArgumentNullException(nameof(oUtilisateurApplication));
            var entity = _mapper.Map<DAL.Models.UtilisateurApplication> (oUtilisateurApplication);
            var id = await _IUtilisateurApplicationRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAll()
        {
            var UtilisateurApplications = await _IUtilisateurApplicationRepository.ChargerAll();
            var model = _mapper.Map<List<UtilisateurApplication>>(UtilisateurApplications);
            return model;
        }


        public async Task<UtilisateurApplication> Recherche(int Id)
        {
            var oUtilisateurApplication = await _IUtilisateurApplicationRepository.Recherche(Id);
            var model = _mapper.Map<UtilisateurApplication>(oUtilisateurApplication);
            return model;
        }


        public async Task<int> Modifier(UtilisateurApplication oUtilisateurApplication)
        {
            if (oUtilisateurApplication == null) throw new ArgumentNullException(nameof(oUtilisateurApplication));
            var entity = _mapper.Map<DAL.Models.UtilisateurApplication>(oUtilisateurApplication);
            var id = await _IUtilisateurApplicationRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Supprimer(int Id)   {   return await _IUtilisateurApplicationRepository.Supprimer(Id);     }



    }
}

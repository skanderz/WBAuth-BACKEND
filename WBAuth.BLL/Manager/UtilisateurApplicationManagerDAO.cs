using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.Manager
{
   public class UtilisateurApplicationManagerDAO : IUtilisateurApplicationManagerDAO
    {
        private readonly IUtilisateurApplicationRepositoryDAO _IUtilisateurApplicationRepository;
        private readonly IMapper _mapper;

        public UtilisateurApplicationManagerDAO(IUtilisateurApplicationRepositoryDAO IUtilisateurApplicationRepository, IMapper mapper)
        {
            _IUtilisateurApplicationRepository = IUtilisateurApplicationRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UtilisateurApplication>> ChargerAll()
        {
            var UtilisateurApplications = await _IUtilisateurApplicationRepository.ChargerAll();
            var model = _mapper.Map<List<UtilisateurApplication>>(UtilisateurApplications);
            return model;
        }
    }
}



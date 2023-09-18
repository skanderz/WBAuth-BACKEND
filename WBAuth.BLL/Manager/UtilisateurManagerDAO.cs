using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.Manager
{
   public class UtilisateurManagerDAO : IUtilisateurManagerDAO
    {
        private readonly IUtilisateurRepositoryDAO _IUtilisateurRepository;
        private readonly IMapper _mapper;

        public UtilisateurManagerDAO(IUtilisateurRepositoryDAO IUtilisateurRepository, IMapper mapper)
        {
            _IUtilisateurRepository = IUtilisateurRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<Utilisateur>> ChargerAll()
        {
            var Utilisateurs = await _IUtilisateurRepository.ChargerAll();
            var model = _mapper.Map<List<Utilisateur>>(Utilisateurs);
            return model;
        }
    }
}



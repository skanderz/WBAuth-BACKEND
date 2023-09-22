using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;


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

        public Task<IEnumerable<UtilisateurApplication>> ChargerAll()
        {
            throw new NotImplementedException();
        }




    }
}



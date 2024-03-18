using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAO.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.Manager
{
    public class PermissionManagerDAO : IPermissionManagerDAO
    {
        private readonly IPermissionRepositoryDAO _IPermissionRepositoryDAO;
        private readonly IMapper _mapper;

        public PermissionManagerDAO(IPermissionRepositoryDAO IPermissionRepositoryDAO, IMapper mapper)
        {
            _IPermissionRepositoryDAO = IPermissionRepositoryDAO;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Permission>> RechercheMultiFonction(string rech, int IdApplication, int IdRole)
        {
            var Permissions = await _IPermissionRepositoryDAO.RechercheMultiFonction(rech, IdApplication, IdRole);
            var models = _mapper.Map<List<Permission>>(Permissions);
            return models;
        }


        public async Task<IEnumerable<Permission>> RechercheFonctionUnique(string rech, int IdApplication, int IdRole)
        {
            var Permissions = await _IPermissionRepositoryDAO.RechercheFonctionUnique(rech, IdApplication, IdRole);
            var models = _mapper.Map<List<Permission>>(Permissions);
            return models;
        }


    }
}
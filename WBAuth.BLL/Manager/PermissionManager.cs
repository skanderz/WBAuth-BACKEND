using AutoMapper;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using WBAuth.DAL.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WBAuth.BLL.Manager
{
    public class PermissionManager : IPermissionManager
    {
        private readonly IPermissionRepository _IPermissionRepository;
        private readonly IMapper _mapper;

        public PermissionManager(IPermissionRepository IPermissionRepository, IMapper mapper)
        {
            _IPermissionRepository = IPermissionRepository;
            _mapper = mapper;
        }



        public async Task<int> Ajouter(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            var entity = _mapper.Map<DAL.Models.Permission>(oPermission);
            var id = await _IPermissionRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            var Permissions = await _IPermissionRepository.ChargerAllFonctionUnique(IdApplication, IdRole);
            var model = _mapper.Map<List<Permission>>(Permissions);
            return model;
        }


        public async Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            var Permissions = await _IPermissionRepository.ChargerAllMultiFonction(IdApplication, IdRole);
            var model = _mapper.Map<List<Permission>>(Permissions);
            return model;
        }


        public async Task<int> Modifier(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            var entity = _mapper.Map<DAL.Models.Permission>(oPermission);
            var id = await _IPermissionRepository.Modifier(entity);
            return id;
        }


        public async Task<int> ModifierAcces(int Id, int i)
        {
            var oPermission = await _IPermissionRepository.RechercheMultiFonctionById(Id);
            var entity = _mapper.Map<DAL.Models.Permission>(oPermission);
            var id = await _IPermissionRepository.ModifierAcces(entity.Id, i);
            return id;
        }


        public async Task<Permission> RechercheFonctionUniqueById(int Id)
        {
            var oPermission = await _IPermissionRepository.RechercheFonctionUniqueById(Id);
            var model = _mapper.Map<Permission>(oPermission);
            return model;
        }


        public async Task<Permission> RechercheMultiFonctionById(int Id)
        {
            var oPermission = await _IPermissionRepository.RechercheMultiFonctionById(Id);
            var model = _mapper.Map<Permission>(oPermission);
            return model;
        }


        public async Task<bool> Supprimer(int Id)
        {
            return await _IPermissionRepository.Supprimer(Id);
        }





    }
}

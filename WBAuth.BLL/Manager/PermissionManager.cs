using WBAuth.DAL.IRepository;
using WBAuth.BLL.IManager;
using WBAuth.BO;
using AutoMapper;
using System;
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
            var entity = _mapper.Map<DAL.Models.Permission> (oPermission);
            var id = await _IPermissionRepository.Ajouter(entity);
            return id;
        }


        public async Task<IEnumerable<Permission>> ChargerAll()
        {
            var Permissions = await _IPermissionRepository.ChargerAll();
            var model = _mapper.Map<List<Permission>>(Permissions);
            return model;
        }


        public async Task<Permission> Recherche(int Id)
        {
            var oPermission = await _IPermissionRepository.Recherche(Id);
            var model = _mapper.Map<Permission>(oPermission);
            return model;
        }


        public async Task<int> Modifier(Permission oPermission)
        {
            if (oPermission == null) throw new ArgumentNullException(nameof(oPermission));
            var entity = _mapper.Map<DAL.Models.Permission>(oPermission);
            var id = await _IPermissionRepository.Modifier(entity);
            return id;
        }


        public async Task<bool> Suprimer(int Id)   {   return await _IPermissionRepository.Suprimer(Id);     }



    }
}

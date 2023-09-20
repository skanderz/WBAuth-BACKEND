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



        public Task<int> Ajouter(Permission oPermission)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> ChargerAllFonctionUnique(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Permission>> ChargerAllMultiFonction(int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<int> Modifier(Permission oPermission)
        {
            throw new NotImplementedException();
        }

        public Task<int> ModifierAcces(int Id, int IdApplication, int IdRole, int i)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> RechercheFonctionUnique(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> RechercheMultiFonction(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Supprimer(int Id, int IdApplication, int IdRole)
        {
            throw new NotImplementedException();
        }





    }
}

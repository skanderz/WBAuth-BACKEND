using AutoMapper;
using WBAuthBack.Mappers;
using WBAuth.BLL.IManager;
using WBAuth.BLL.Manager;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Repository;
using WBAuth.DAO.IRepository;
using WBAuth.DAO.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace WBAuthBack
{
    internal class ServicesConfig
    {
        internal static void CreateServices(IServiceCollection services)
        {
            AutoMapper.MapperConfiguration mappingConfig = new MapperConfiguration(mc =>{ mc.AddProfile(InitializeMappers()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationManager, ApplicationManager>();
            services.AddScoped<IApplicationRepositoryDAO, ApplicationRepositoryDAO>();
            services.AddScoped<IApplicationManagerDAO, ApplicationManagerDAO>();
            //
            services.AddScoped<IActionRepository, ActionRepository>();
            services.AddScoped<IActionManager, ActionManager>();
            services.AddScoped<IActionRepositoryDAO, ActionRepositoryDAO>();
            services.AddScoped<IActionManagerDAO, ActionManagerDAO>();
            //
            services.AddScoped<IFonctionRepository, FonctionRepository>();
            services.AddScoped<IFonctionManager, FonctionManager>();
            services.AddScoped<IFonctionRepositoryDAO, FonctionRepositoryDAO>();
            services.AddScoped<IFonctionManagerDAO, FonctionManagerDAO>();
            //
            services.AddScoped<IJournalisationRepository, JournalisationRepository>();
            services.AddScoped<IJournalisationManager, JournalisationManager>();
            services.AddScoped<IJournalisationRepositoryDAO, JournalisationRepositoryDAO>();
            services.AddScoped<IJournalisationManagerDAO, JournalisationManagerDAO>();
            //
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionManager, PermissionManager>();
            services.AddScoped<IPermissionRepositoryDAO, PermissionRepositoryDAO>();
            services.AddScoped<IPermissionManagerDAO, PermissionManagerDAO>();
            //
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleManager, RoleManager>();
            services.AddScoped<IRoleRepositoryDAO, RoleRepositoryDAO>();
            services.AddScoped<IRoleManagerDAO, RoleManagerDAO>();
            //
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            services.AddScoped<IUtilisateurManager, UtilisateurManager>();
            services.AddScoped<IUtilisateurRepositoryDAO, UtilisateurRepositoryDAO>();
            services.AddScoped<IUtilisateurManagerDAO, UtilisateurManagerDAO>();
            //
            services.AddScoped<IUtilisateurApplicationRepository, UtilisateurApplicationRepository>();
            services.AddScoped<IUtilisateurApplicationManager, UtilisateurApplicationManager>();
            services.AddScoped<IUtilisateurApplicationRepositoryDAO, UtilisateurApplicationRepositoryDAO>();
            services.AddScoped<IUtilisateurApplicationManagerDAO, UtilisateurApplicationManagerDAO>();
        }


        private static MapperProfile InitializeMappers() { return new MapperProfile();  }
    }
}



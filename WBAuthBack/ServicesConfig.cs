using AutoMapper;
using WBAuth.Back.Mappers;
using WBAuth.BLL.IManager;
using WBAuth.BLL.Manager;
using WBAuth.DAL.IRepository;
using WBAuth.DAL.Repository;
using WBAuth.DAO.IRepository;
using WBAuth.DAO.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace WBAuth.Back
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
            //
            services.AddScoped<IActionRepository, ActionRepository>();
            services.AddScoped<IActionManager, ActionManager>();
            //
            services.AddScoped<IFonctionRepository, FonctionRepository>();
            services.AddScoped<IFonctionManager, FonctionManager>();
            //
            services.AddScoped<IJournalisationRepository, JournalisationRepository>();
            services.AddScoped<IJournalisationManager, JournalisationManager>();
            //
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionManager, PermissionManager>();
            services.AddScoped<IPermissionRepositoryDAO, PermissionRepositoryDAO>();
            services.AddScoped<IPermissionManagerDAO, PermissionManagerDAO>();
            //
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleManager, RoleManager>();
            //
            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            services.AddScoped<IUtilisateurManager, UtilisateurManager>();
            //
            services.AddScoped<IUtilisateurApplicationRepository, UtilisateurApplicationRepository>();
            services.AddScoped<IUtilisateurApplicationManager, UtilisateurApplicationManager>();
        }


        private static MapperProfile InitializeMappers() { return new MapperProfile();  }
    }
}



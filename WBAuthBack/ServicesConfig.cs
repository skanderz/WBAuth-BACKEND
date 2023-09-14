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
        }


        private static MapperProfile InitializeMappers() { return new MapperProfile();  }
    }
}



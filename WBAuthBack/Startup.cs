using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WBAuth.Data;


namespace Clean_API_Architecture
{
    public class Startup
    {
        public Startup(IConfiguration configuration)   {    Configuration = configuration;   }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        services.AddDbContext<ApplicationDbContext>
                 (opt => opt.UseSqlServer(Configuration["Data:sqlConnectionString:ConnectionString"]));
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        ServicesConfig.CreateServices(services);   
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()){  app.UseDeveloperExceptionPage(); }
            else { app.UseHsts(); }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}



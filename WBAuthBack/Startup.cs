using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WBAuth.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using WBAuthBack;



namespace WBAuthBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)   {    Configuration = configuration;   }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration["Data:ConnectionStrings:sqlConnectionString"]));

            // For Identity 
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


            // Adding Authentification
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            // Add services to the container.
            services.AddCors(options => { options.AddPolicy("AllowAngularFrontend", 
                             builder => { builder.WithOrigins("https://localhost:44424/")
                                         .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();   }); });
            services.AddControllers();
            services.AddSwaggerGen();

            ServicesConfig.CreateServices(services);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAngularFrontend");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("AllowAngularFrontend");
                endpoints.MapControllerRoute( name: "default",  pattern: "{controller}/{action}/{id?}" );
                endpoints.MapFallbackToFile("index.html");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else { app.UseHsts(); }




        }
    }
}



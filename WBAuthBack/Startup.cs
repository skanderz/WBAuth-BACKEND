using WBAuth.DAL.Models;
using WBAuth.BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WBAuth.Back.JwtFeatures;
using Microsoft.OpenApi.Models;
using WBAuth.BLL.Manager;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace WBAuth.Back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)   {    Configuration = configuration;   }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.



        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration["Data:ConnectionStrings:sqlConnectionString"]));
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            // For Identity 
            services.AddIdentity<WBAuth.DAL.Models.Utilisateur, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
            });


            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(120));

            //Email Configuration
            services.AddScoped<JwtHandler>();
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();


           //Authentification
           var jwtSettings = Configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = "Authentification";
                opt.DefaultChallengeScheme = "Authentification";
                opt.DefaultScheme = "Authentification";
            }).AddJwtBearer("Authentification", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });


            services.AddHttpClient();


            // FrontEnd Configuration
            services.AddCors(opt =>
            {
              opt.AddPolicy(name: "AllowAngularFrontend", builder =>
              {
                 builder.WithOrigins("https://localhost:44429", "http://localhost:44429" ,"https://localhost:44466" ,"http://localhost:44466"
                                    ,"https://localhost:7281", "http://localhost:7281")
                        .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
              });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

                // Configuration de l'authentification pour Swagger
                c.AddSecurityDefinition("Authentification", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Authentification scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Authentification"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {    new OpenApiSecurityScheme
                    {    Reference = new OpenApiReference
                     {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Authentification"
                             }
                        },
                    new string[] { }
                    }
                });
            });


            ServicesConfig.CreateServices(services);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("AllowAngularFrontend");
            app.UseHttpsRedirection();
            app.UseAuthentication();
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



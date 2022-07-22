
using BrianTech008Api.Data;
using BrianTech008Api.Data.Models;
using BrianTech008Api.Features.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BrianTech008Api.Extensions
{
    public static class ServiceCollectionExtensions
    {


        public static AppSettings GetApplicationSettings(this IServiceCollection services,
                                                  IConfiguration configuration)
        {
            // configure strongly typed settings objects
            var applicationSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfig);
            return applicationSettingsConfig.Get<AppSettings>();


        }


        public static IServiceCollection AddDatabase(this IServiceCollection services,
                                                      IConfiguration configuration)
               => services.AddDbContext<DataContext>(options => options
                    .UseNpgsql(configuration.GetDefaultConnectionString()));

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(
                  options =>
                  {
                      // options.SignIn.RequireConfirmedAccount = false;
                      options.Password.RequireDigit = false;
                      options.Password.RequireLowercase = true;
                      options.Password.RequireNonAlphanumeric = false;
                      options.Password.RequireUppercase = false;
                      options.Password.RequiredLength = 6;
                      //options.Password.RequiredUniqueChars = 1;
                  }
                  )
                       .AddEntityFrameworkStores<DataContext>()
                       .AddRoles<IdentityRole>();
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
                                                              AppSettings appSettings)
        {


            // configure jwt authentication

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
      => services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            //.AddScoped<IProjectRepository, ProjectRepository>()
          
            .AddTransient<IIdentityService, IdentityService>()
            .AddScoped<JwtHandler>();






            public static IServiceCollection AddSwagger(this IServiceCollection services)
            =>   services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BrianTech008Api", Version = "v1" });
            });
        

    }
}

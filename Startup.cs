
using BrianTech008Api.Extensions;
using BrianTech008Api.Helpers;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace BrianTech008Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services
                .Configure<MailSettings>(Configuration.GetSection("MailSettings"))
                .AddTransient<IMailService, MailService>()
                .AddDatabase(this.Configuration)
                .AddIdentity()
               
                //.AddRoles<IdentityRole>()
                .AddJwtAuthentication(services.GetApplicationSettings(this.Configuration))
                .AddAutoMapper(typeof(AutoMapperProfiles).Assembly)
                .AddApplicationServices()
                .AddSwagger()
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(
                                           builder =>
                                           {
                                               builder.WithOrigins("https://admin.zuricosmetics.co.ke","http://localhost:4200")
                                                                   .AllowAnyHeader()
                                                                   .AllowAnyMethod()
                                                                   .AllowCredentials();
                                           });
                })
                .AddControllers();


            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

        }

        // This method gets c
        // alled by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            app.UseSwaggerUI();
            app.UseRouting();
            // global cors policy
            app.UseCors(); 

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.ApplyMigrations();
        }
    }
}

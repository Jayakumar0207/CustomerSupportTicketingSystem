using UserAuthService.Application.Mappers;
using UserAuthService.Application.Repositories;
using UserAuthService.Application.Services.Abstractions;
using UserAuthService.Infrastructure.Persistence;
using UserAuthService.Infrastructure.Persistence.Repositories;
using UserAuthService.Application.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AuthService.Infrastructure
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //DBContext
            services.AddDbContext<AuthServiceDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserDBContext"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("UserAuthService.API");
                }
                ));
            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //Services
            services.AddScoped<IUserAppService, UserAppService>();

            //AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<UserMapper>());
        }
    }
}

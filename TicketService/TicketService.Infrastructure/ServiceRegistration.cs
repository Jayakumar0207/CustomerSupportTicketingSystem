using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketService.Application.Repository;
using TicketService.Application.Services.Abstraction;
using TicketService.Application.Services.Implementation;
using TicketService.Domain.Entities;
using TicketService.Infrastructure.Repositories;
using TicketServices.API.Mapper;

namespace TicketService.Infrastructure
{
    public class ServiceRegistration
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext
            services.AddDbContext<TicketServiceDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TicketDbContext"), 
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("TicketService.API");
                }                
                ));

            // Register application services
            services.AddScoped<ITicketAppService, TicketAppService>();

            // Register repositories
            services.AddScoped<ITicketServiceRepository, TicketServiceRepository>();

            // Register AutoMapper
            services.AddAutoMapper(cfg => cfg.AddProfile<TicketMapper>());
        }
    }
}

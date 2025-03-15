using MauiAppPrueba.Application.Services;
using MauiAppPrueba.Domain.Interfaces;
using MauiAppPrueba.Domain.UnitOfWork;
using MauiAppPrueba.Infrastructure.Data;
using MauiAppPrueba.Infrastructure.Repositories;
using MauiAppPrueba.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace MauiAppPrueba.API.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeServices, EmployeeService>();

            return services;
        }

    }
}

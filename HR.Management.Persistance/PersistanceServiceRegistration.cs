using HR.Management.Application.Contracts.Persistance;
using HR.Management.Persistance.DatabaseContexts;
using HR.Management.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Management.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register persistence services here
            services.AddDbContext<HrDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}

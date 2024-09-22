using Infrastructure.Data.Abstractions;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(services));
            ArgumentNullException.ThrowIfNull(nameof(configuration));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<CustomerDbContext>(dbContextBuilder =>
            {
                string? connectionString = configuration.GetConnectionString("Customer");

                ArgumentNullException.ThrowIfNull(nameof(connectionString));

                dbContextBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}

using Application.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));
        ArgumentNullException.ThrowIfNull(nameof(configuration));

        Infrastructure.Startup.ConfigureServices(services, configuration);

        services.AddApplicationServices(configuration);
    }
}
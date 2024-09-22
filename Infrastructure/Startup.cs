using Infrastructure.Data.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(nameof(services));
        ArgumentNullException.ThrowIfNull(nameof(configuration));

        services.AddDataServices(configuration);
    }
}

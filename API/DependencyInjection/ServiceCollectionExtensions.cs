namespace API.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        Application.Startup.ConfigureServices(services, configuration);

        return services;
    }
}

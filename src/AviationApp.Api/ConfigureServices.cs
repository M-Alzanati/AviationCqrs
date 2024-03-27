using AviationApp.Application;
using AviationApp.Infrastructure;

namespace AviationApp.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices(configuration);
        
        return services;
    }
}
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AviationApp.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
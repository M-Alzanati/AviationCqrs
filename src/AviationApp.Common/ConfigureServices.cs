using AviationApp.Common.Clients.AviationStack;
using Microsoft.Extensions.DependencyInjection;

namespace AviationApp.Common;

public static class ConfigureServices
{
    public static IServiceCollection AddRestClients(this IServiceCollection services)
    {
        services.AddScoped<IAviationStackClient, AviationStackClient>();

        return services;
    }
}
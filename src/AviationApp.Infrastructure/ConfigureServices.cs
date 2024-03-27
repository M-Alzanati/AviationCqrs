using AviationApp.Application.Common.Interface;
using AviationApp.Common;
using AviationApp.Domain.Interfaces;
using AviationApp.Infrastructure.Data;
using AviationApp.Infrastructure.Repositories;
using AviationApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AviationApp.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AviationDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21))));

        services.AddScoped<IFlightRepository, FlightRepository>();
        services.AddScoped<IAirportRepository, AirportRepository>();
        
        services.AddScoped<IAviationStackService, AviationStackService>();
        services.AddScoped<IFlightService, FlightService>();
        services.AddScoped<IAirportService, AirportService>();

        services.AddRestClients();
        return services;
    }
}
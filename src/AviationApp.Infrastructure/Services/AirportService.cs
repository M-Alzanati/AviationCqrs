using AutoMapper;
using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using AviationApp.Domain.Repositories;

namespace AviationApp.Infrastructure.Services;

public class AirportService(IAviationStackService aviationStackService, IAirportRepository airportRepository, IMapper mapper) : IAirportService
{
    public async Task<bool> CanImportAirports(CancellationToken cancellationToken)
    {
        return await airportRepository.Any(cancellationToken);
    }

    public async Task ImportAirports(CancellationToken cancellationToken)
    {
        var airports = await aviationStackService.GetAirportsData(cancellationToken);

        if (airports.Data == null || !airports.Data.Any())
        {
            return;
        }
        
        foreach (var airport in airports.Data)
        {
            var data = mapper.Map<Airport>(airport);
            await airportRepository.Insert(data, cancellationToken);
        }

        await airportRepository.Save(cancellationToken);
    }

    public async Task<IEnumerable<Airport>> GetPaginatedAirports(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await airportRepository.GetAirports(pageNumber, pageSize, cancellationToken);
    }
}
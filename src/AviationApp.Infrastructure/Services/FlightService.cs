using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;

namespace AviationApp.Infrastructure.Services;

public class FlightService(IAviationStackService aviationStackService, IFlightRepository flightRepository, IMapper mapper) : IFlightService
{
    public async Task<bool> CanImportFlights(CancellationToken cancellationToken)
    {
        return await flightRepository.Any(cancellationToken);
    }

    public async Task ImportFlights(CancellationToken cancellationToken)
    {
        var flights = await aviationStackService.GetFlightsData(cancellationToken);

        if (flights.Data == null || !flights.Data.Any())
        {
            return;
        }
        
        foreach (var flight in flights.Data)
        {
            var data = mapper.Map<Flight>(flight);
            await flightRepository.Insert(data, cancellationToken);
        }

        await flightRepository.Save(cancellationToken);
    }

    public async Task<IEnumerable<Flight>> GetPaginatedFlights(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await flightRepository.GetFlights(pageNumber, pageSize, cancellationToken);
    }
}
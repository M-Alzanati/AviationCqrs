using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Services;

public interface IFlightService
{
    Task<bool> CanImportFlights(CancellationToken cancellationToken);
    
    Task ImportFlights(CancellationToken cancellationToken);
    
    Task<IEnumerable<Flight>> GetPaginatedFlights(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<IEnumerable<Flight>> GetPaginatedFlights(string? iataCode, int pageNumber, int pageSize, CancellationToken cancellationToken);
}
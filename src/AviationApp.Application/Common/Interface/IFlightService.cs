using AviationApp.Domain.Entities;

namespace AviationApp.Application.Common.Interface;

public interface IFlightService
{
    Task<bool> CanImportFlights(CancellationToken cancellationToken);
    
    Task ImportFlights(CancellationToken cancellationToken);
    
    Task<IEnumerable<Flight>> GetPaginatedFlights(int pageNumber, int pageSize, CancellationToken cancellationToken);
}
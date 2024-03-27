using AviationApp.Domain.Entities;

namespace AviationApp.Application.Common.Interface;

public interface IAirportService
{
    Task<bool> CanImportAirports(CancellationToken cancellationToken);
    
    Task ImportAirports(CancellationToken cancellationToken);
    
    Task<IEnumerable<Airport>> GetPaginatedAirports(int pageNumber, int pageSize, CancellationToken cancellationToken);
}
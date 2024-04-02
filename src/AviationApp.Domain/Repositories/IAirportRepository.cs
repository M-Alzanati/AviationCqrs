using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Repositories;

public interface IAirportRepository : IRepository<Airport>
{
    Task<IEnumerable<Airport>> GetAirports(int page, int size, CancellationToken cancellationToken);
}
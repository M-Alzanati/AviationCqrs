using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Interfaces;

public interface IAirportRepository : IRepository<Airport>
{
    Task<IEnumerable<Airport>> GetAirports(int page, int size, CancellationToken cancellationToken);
}
using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Repositories;

public interface IFlightRepository : IRepository<Flight>
{
    Task<IEnumerable<Flight>> GetFlights(int page, int size, CancellationToken cancellationToken);
}
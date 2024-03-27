using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Interfaces;

public interface IFlightRepository : IRepository<Flight>
{
    Task<IEnumerable<Flight>> GetFlights(int page, int size, CancellationToken cancellationToken);
}
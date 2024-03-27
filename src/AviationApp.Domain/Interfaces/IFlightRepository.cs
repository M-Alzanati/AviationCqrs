using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Interfaces;

public interface IFlightRepository : IGenericRepository<Flight>
{
    Task<IEnumerable<Flight>> GetFlights(int page, int size);
}
using AviationApp.Domain.Entities;

namespace AviationApp.Domain.Interfaces;

public interface IAirportRepository : IGenericRepository<Airport>
{
    Task<IEnumerable<Airport>> GetAirports(int page, int size);
}
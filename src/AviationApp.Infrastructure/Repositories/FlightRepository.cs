using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using AviationApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AviationApp.Infrastructure.Repositories;

public class FlightRepository : Repository<Flight>, IFlightRepository
{
    private readonly AviationDbContext _context;

    public FlightRepository(AviationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Flight>> GetFlights(int page, int size, CancellationToken cancellationToken)
    {
        return await _context.Flights
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);
    }
}
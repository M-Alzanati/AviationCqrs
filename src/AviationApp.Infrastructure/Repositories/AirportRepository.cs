using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using AviationApp.Domain.Repositories;
using AviationApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AviationApp.Infrastructure.Repositories;

public class AirportRepository : Repository<Airport>, IAirportRepository
{
    private readonly AviationDbContext _context;

    public AirportRepository(AviationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Airport>> GetAirports(int page, int size, CancellationToken cancellationToken)
    {
        return await _context.Airports
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }
}
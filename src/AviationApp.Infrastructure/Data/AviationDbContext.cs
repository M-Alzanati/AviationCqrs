using System.Reflection;
using Microsoft.EntityFrameworkCore;
using AviationApp.Domain.Entities;

namespace AviationApp.Infrastructure.Data;

public class AviationDbContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Airport> Airports { get; set; }
    
    public AviationDbContext(DbContextOptions<AviationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
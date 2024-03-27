using AviationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationApp.Infrastructure.Data.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("flight");

        builder.HasKey(t => t.Id)
            .HasName("id");

        builder.Property(t => t.AirlineName)
            .HasColumnName("airline_name")
            .IsRequired(false);
        
        builder.Property(t => t.FlightNumber)
            .HasColumnName("flight_number")
            .HasDefaultValue(null);

        builder.Property(t => t.ArrivalScheduled)
            .HasColumnName("arrival_scheduled")
            .HasDefaultValue(null);
        
        builder.Property(t => t.ArrivalAirport)
            .HasColumnName("arrival_airport")
            .HasDefaultValue(null);
        
        builder.Property(t => t.FlightDate)
            .HasColumnName("flight_date")
            .HasDefaultValue(null);
        
        builder.Property(t => t.DepartureScheduled)
            .HasColumnName("departure_scheduled")
            .HasDefaultValue(null);
        
        builder.Property(t => t.DepartureAirport)
            .HasColumnName("departure_airport")
            .HasDefaultValue(null);
        
        builder.Property(t => t.FlightStatus)
            .HasColumnName("flight_status")
            .HasDefaultValue(null);
        
        builder.Property(t => t.ArrivalIataCode)
            .HasColumnName("arrival_iata_code")
            .HasDefaultValue(null);
        
        builder.Property(t => t.DepartureIataCode)
            .HasColumnName("departure_iata_code")
            .HasDefaultValue(null);
    }
}
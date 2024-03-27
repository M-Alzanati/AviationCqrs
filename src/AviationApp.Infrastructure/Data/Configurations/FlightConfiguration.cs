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
            .HasColumnName("flight_number");

        builder.Property(t => t.ArrivalScheduled)
            .HasColumnName("arrival_scheduled");
        
        builder.Property(t => t.ArrivalAirport)
            .HasColumnName("arrival_airport");
        
        builder.Property(t => t.FlightDate)
            .HasColumnName("flight_date");
        
        builder.Property(t => t.DepartureScheduled)
            .HasColumnName("departure_scheduled");
        
        builder.Property(t => t.DepartureAirport)
            .HasColumnName("departure_airport");
        
        builder.Property(t => t.FlightStatus)
            .HasColumnName("flight_status");
    }
}
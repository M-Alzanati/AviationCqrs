using AviationApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviationApp.Infrastructure.Data.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.ToTable("airport");
        
        builder.HasKey(t => t.Id)
            .HasName("id");
        
        builder.Property(t => t.Timezone)
            .HasColumnName("timezone")
            .HasDefaultValue(null);
        
        builder.Property(t => t.AirportName)
            .HasColumnName("airport_name")
            .HasDefaultValue(null);
        
        builder.Property(t => t.AirportId)
            .HasColumnName("airport_id")
            .HasDefaultValue(null);
        
        builder.Property(t => t.CountryName)
            .HasColumnName("country_name")
            .HasDefaultValue(null);
    }
}
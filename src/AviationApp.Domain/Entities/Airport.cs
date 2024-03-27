using AviationApp.Domain.Entities.Base;

namespace AviationApp.Domain.Entities;

public class Airport : IEntity
{
    public int Id { get; set; }
    
    public int AirportId { set; get; }
    
    public string? AirportName { set; get; }
    
    public string? Timezone { set; get; }
    
    public string? CountryName { set; get; }
    
    public string? IataCode { set; get; }
}
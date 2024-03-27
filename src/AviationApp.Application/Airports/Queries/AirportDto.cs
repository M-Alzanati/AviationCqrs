namespace AviationApp.Application.Airports.Queries;

public class AirportDto
{
    public int AirportId { set; get; }
    
    public string AirportName { set; get; }
    
    public string Timezone { set; get; }
    
    public string? CountryName { set; get; }
}
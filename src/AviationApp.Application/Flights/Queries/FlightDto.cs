namespace AviationApp.Application.Flights.Queries;

public class FlightDto
{
    public DateTime FlightDate { get; set; }
    
    public string FlightStatus { get; set; }
    
    public string DepartureAirport { get; set; }
    
    public DateTime DepartureScheduled { get; set; }
    
    public string? ArrivalAirport { get; set; }
    
    public DateTime ArrivalScheduled { get; set; }

    public string AirlineName { get; set; }
    
    public string FlightNumber { get; set; }
}
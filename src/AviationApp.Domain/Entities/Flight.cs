using AviationApp.Domain.Entities.Base;

namespace AviationApp.Domain.Entities;

public class Flight : IEntity
{
    public int Id { get; set; }
    
    public DateTime FlightDate { get; set; }
    
    public string? FlightStatus { get; set; }
    
    public string? DepartureAirport { get; set; }
    
    public DateTime DepartureScheduled { get; set; }
    
    public string? ArrivalAirport { get; set; }
    
    public DateTime ArrivalScheduled { get; set; }

    public string? AirlineName { get; set; }
    
    public string? FlightNumber { get; set; }
    
    public string? ArrivalIataCode { get; set; }
    
    public string? DepartureIataCode { get; set; }
}
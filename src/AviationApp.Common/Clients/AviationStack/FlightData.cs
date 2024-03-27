namespace AviationApp.Common.Clients.AviationStack;

public class FlightData : BaseAviationStackResponse<FlightInfo>
{
    public override IEnumerable<FlightInfo>? Data { get; set; }
}

public class FlightInfo
{
    public string? FlightDate { get; set; }
    public string? FlightStatus { get; set; }
    public LocationInfo? Departure { get; set; }
    public LocationInfo? Arrival { get; set; }
    public AirlineInfo? Airline { get; set; }
    public Flight? Flight { get; set; }
    public object? Aircraft { get; set; }
    public object? Live { get; set; }
}

public class LocationInfo
{
    public string? Airport { get; set; }
    public string? Timezone { get; set; }
    public string? Iata { get; set; }
    public string? Icao { get; set; }
    public string? Terminal { get; set; }
    public string? Gate { get; set; }
    public string? Delay { get; set; }
    public string? Scheduled { get; set; }
    public string? Estimated { get; set; }
    public string? Actual { get; set; }
    public string? EstimatedRunway { get; set; }
    public string? ActualRunway { get; set; }
}

public class AirlineInfo
{
    public string? Name { get; set; }
    public string? Iata { get; set; }
    public string? Icao { get; set; }
}

public class Flight
{
    public string? Number { get; set; }
    public string? Iata { get; set; }
    public string? Icao { get; set; }
    public Codeshared? Codeshared { get; set; }
}

public class Codeshared
{
    public string? AirlineName { get; set; }
    public string? AirlineIata { get; set; }
    public string? AirlineIcao { get; set; }
    public string? FlightNumber { get; set; }
    public string? FlightIata { get; set; }
    public string? FlightIcao { get; set; }
}
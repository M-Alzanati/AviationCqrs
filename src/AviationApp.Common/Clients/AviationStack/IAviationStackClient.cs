namespace AviationApp.Common.Clients.AviationStack;

public interface IAviationStackClient
{
    Task<FlightData> GetFlightsData(CancellationToken cancellationToken);

    Task<AirportData> GetAirportsData(CancellationToken cancellationToken);
}
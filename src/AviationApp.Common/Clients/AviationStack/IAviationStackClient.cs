namespace AviationApp.Common.Clients.AviationStack;

public interface IAviationStackClient
{
    Task<FlightData> GetFlightsData(CancellationToken cancellationToken);
}
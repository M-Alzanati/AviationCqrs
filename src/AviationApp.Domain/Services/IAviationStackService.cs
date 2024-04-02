using AviationApp.Common.Clients.AviationStack;

namespace AviationApp.Domain.Services;

public interface IAviationStackService
{
    Task<FlightData> GetFlightsData(CancellationToken cancellationToken);

    Task<AirportData> GetAirportsData(CancellationToken cancellationToken);
}
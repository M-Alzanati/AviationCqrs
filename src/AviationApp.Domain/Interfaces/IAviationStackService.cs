using AviationApp.Common.Clients.AviationStack;

namespace AviationApp.Domain.Interfaces;

public interface IAviationStackService
{
    Task<FlightData> GetFlightsData(CancellationToken cancellationToken);

    Task<AirportData> GetAirportsData(CancellationToken cancellationToken);
}
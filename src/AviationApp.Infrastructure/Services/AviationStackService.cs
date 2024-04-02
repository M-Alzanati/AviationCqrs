using AviationApp.Common.Clients.AviationStack;
using AviationApp.Domain.Services;

namespace AviationApp.Infrastructure.Services;

public class AviationStackService(IAviationStackClient aviationStackClient) : IAviationStackService
{
    public Task<FlightData> GetFlightsData(CancellationToken cancellationToken)
    {
        return aviationStackClient.GetFlightsData(cancellationToken);
    }
    
    public Task<AirportData> GetAirportsData(CancellationToken cancellationToken)
    {
        return aviationStackClient.GetAirportsData(cancellationToken);
    }
}
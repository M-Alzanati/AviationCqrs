using AviationApp.Application.Common.Interface;
using AviationApp.Common.Clients.AviationStack;

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
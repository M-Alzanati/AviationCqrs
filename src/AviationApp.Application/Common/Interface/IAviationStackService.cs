using AviationApp.Common.Clients.AviationStack;

namespace AviationApp.Application.Common.Interface;

public interface IAviationStackService
{
    Task<FlightData> GetFlightsData(CancellationToken cancellationToken);
}
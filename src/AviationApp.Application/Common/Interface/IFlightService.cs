using AviationApp.Common.Clients.AviationStack;

namespace AviationApp.Application.Common.Interface;

public interface IFlightService
{
    Task<bool> CanImportFlights(CancellationToken cancellationToken);
    
    Task ImportFlights(CancellationToken cancellationToken);
}
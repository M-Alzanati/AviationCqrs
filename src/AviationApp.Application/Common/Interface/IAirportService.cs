using AviationApp.Common.Clients.AviationStack;

namespace AviationApp.Application.Common.Interface;

public interface IAirportService
{
    Task<bool> CanImportAirports(CancellationToken cancellationToken);
    
    Task ImportAirports(CancellationToken cancellationToken);
}
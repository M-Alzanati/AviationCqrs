using AviationApp.Application.Common.Interface;
using MediatR;

namespace AviationApp.Application.Flights.Commands;

public class ImportFlightsCommand : IRequest<bool>
{
    
}

public class ImportFlightsCommandHandler(IFlightService flightService) : IRequestHandler<ImportFlightsCommand, bool>
{
    public async Task<bool> Handle(ImportFlightsCommand request, CancellationToken cancellationToken)
    {
        if (await flightService.CanImportFlights(cancellationToken)) return false;
        
        await flightService.ImportFlights(cancellationToken);
        return true;
    }
}
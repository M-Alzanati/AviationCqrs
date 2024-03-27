using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Flights.Commands;

public class ImportFlightsCommand : IRequest<ApiResponse<object>>
{
    
}

public class ImportFlightsCommandHandler(IFlightService flightService) : IRequestHandler<ImportFlightsCommand, ApiResponse<object>>
{
    public async Task<ApiResponse<object>> Handle(ImportFlightsCommand request, CancellationToken cancellationToken)
    {
        if (await flightService.CanImportFlights(cancellationToken))
        {
            return new ApiResponse<object>(null!, false, "Data already imported");
        }
        
        await flightService.ImportFlights(cancellationToken);
        return ApiResponse<object>.Create(null!, true, "Data Imported successfully");
    }
}
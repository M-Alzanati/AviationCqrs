using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Airports.Commands;

public class ImportAirportsCommand : IRequest<ApiResponse<object>>
{
    
}

public class ImportAirportsCommandHandler(IAirportService airportService) : IRequestHandler<ImportAirportsCommand, ApiResponse<object>>
{
    public async Task<ApiResponse<object>> Handle(ImportAirportsCommand request, CancellationToken cancellationToken)
    {
        if (await airportService.CanImportAirports(cancellationToken))
        {
            return new ApiResponse<object>(null!, false, "Data already imported");
        }
        
        await airportService.ImportAirports(cancellationToken);
        return ApiResponse<object>.Create(null!, true, "Data Imported successfully");
    }
}
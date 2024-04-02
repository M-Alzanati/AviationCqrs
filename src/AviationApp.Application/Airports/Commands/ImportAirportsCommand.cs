using AviationApp.Common.Data;
using AviationApp.Domain.Services;
using MediatR;

namespace AviationApp.Application.Airports.Commands;

/// <summary>
/// ImportAirportsCommand is a command class that implements IRequest interface.
/// It is used to import airports data.
/// </summary>
public class ImportAirportsCommand : IRequest<ApiResponse<object>>
{

}

/// <summary>
/// ImportAirportsCommandHandler is a handler class for ImportAirportsCommand.
/// It implements IRequestHandler interface and handles the execution of the command.
/// </summary>
public class ImportAirportsCommandHandler : IRequestHandler<ImportAirportsCommand, ApiResponse<object>>
{
    private readonly IAirportService _airportService;

    /// <summary>
    /// Constructor for the ImportAirportsCommandHandler class.
    /// </summary>
    /// <param name="airportService">An instance of IAirportService, used to interact with the airports data.</param>
    public ImportAirportsCommandHandler(IAirportService airportService)
    {
        _airportService = airportService;
    }

    /// <summary>
    /// Handle is a method that handles the execution of the ImportAirportsCommand.
    /// It checks if the airports data can be imported, and if so, it imports the data.
    /// </summary>
    /// <param name="request">An instance of ImportAirportsCommand, which is the command to be executed.</param>
    /// <param name="cancellationToken">A CancellationToken that can be used to cancel the operation.</param>
    /// <returns>A Task that represents the asynchronous operation, with an ApiResponse<object> that contains the result of the operation.</returns>
    public async Task<ApiResponse<object>> Handle(ImportAirportsCommand request, CancellationToken cancellationToken)
    {
        if (await _airportService.CanImportAirports(cancellationToken))
        {
            return new ApiResponse<object>(null!, false, "Data already imported");
        }

        await _airportService.ImportAirports(cancellationToken);
        return ApiResponse<object>.Create(null!, true, "Data Imported successfully");
    }
}
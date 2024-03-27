using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Flights.Commands;

/// <summary>
/// ImportFlightsCommand is a command class that implements IRequest interface.
/// It is used to import flights data.
/// </summary>
public class ImportFlightsCommand : IRequest<ApiResponse<object>>
{

}

/// <summary>
/// ImportFlightsCommandHandler is a handler class for ImportFlightsCommand.
/// It implements IRequestHandler interface and handles the execution of the command.
/// </summary>
public class ImportFlightsCommandHandler : IRequestHandler<ImportFlightsCommand, ApiResponse<object>>
{
    private readonly IFlightService _flightService;

    /// <summary>
    /// Constructor for the ImportFlightsCommandHandler class.
    /// </summary>
    /// <param name="flightService">An instance of IFlightService, used to interact with the flights data.</param>
    public ImportFlightsCommandHandler(IFlightService flightService)
    {
        _flightService = flightService;
    }

    /// <summary>
    /// Handle is a method that handles the execution of the ImportFlightsCommand.
    /// It checks if the flights data can be imported, and if so, it imports the data.
    /// </summary>
    /// <param name="request">An instance of ImportFlightsCommand, which is the command to be executed.</param>
    /// <param name="cancellationToken">A CancellationToken that can be used to cancel the operation.</param>
    /// <returns>A Task that represents the asynchronous operation, with an ApiResponse<object> that contains the result of the operation.</returns>
    public async Task<ApiResponse<object>> Handle(ImportFlightsCommand request, CancellationToken cancellationToken)
    {
        if (await _flightService.CanImportFlights(cancellationToken))
        {
            return new ApiResponse<object>(null!, false, "Data already imported");
        }

        await _flightService.ImportFlights(cancellationToken);
        return ApiResponse<object>.Create(null!, true, "Data Imported successfully");
    }
}
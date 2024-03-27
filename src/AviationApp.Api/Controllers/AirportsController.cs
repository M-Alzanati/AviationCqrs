using AviationApp.Application.Airports.Commands;
using AviationApp.Application.Airports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviationApp.Api.Controllers;

/// <summary>
/// AirportsController is a controller class that handles HTTP requests related to airports.
/// It uses the Mediator pattern to send commands and queries to the application layer.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AirportsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor for the AirportsController class.
    /// </summary>
    /// <param name="mediator">An instance of IMediator, used to send commands and queries.</param>
    public AirportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// ImportAirports is an action method that handles HTTP POST requests to import airports.
    /// </summary>
    /// <param name="command">An instance of ImportAirportsCommand, which contains the data for the airports to be imported.</param>
    /// <returns>A Task that represents the asynchronous operation, with an IActionResult that contains the result of the operation.</returns>
    [HttpPost]
    [Route("import")]
    public async Task<IActionResult> ImportAirports([FromBody] ImportAirportsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    /// <summary>
    /// GetFlights is an action method that handles HTTP GET requests to retrieve airports.
    /// </summary>
    /// <param name="query">An instance of GetAirportsWithPaginationQuery, which contains the parameters for the query.</param>
    /// <returns>A Task that represents the asynchronous operation, with an IActionResult that contains the result of the operation.</returns>
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetFlights([FromQuery] GetAirportsWithPaginationQuery query)
    {
        var flights = await _mediator.Send(query);
        return Ok(flights);
    }
}
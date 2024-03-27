using AviationApp.Application.Flights.Commands;
using AviationApp.Application.Flights.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviationApp.Api.Controllers;

/// <summary>
/// FlightsController is a controller class that handles HTTP requests related to flights.
/// It uses the Mediator pattern to send commands and queries to the application layer.
/// </summary>
[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Constructor for the FlightsController class.
    /// </summary>
    /// <param name="mediator">An instance of IMediator, used to send commands and queries.</param>
    public FlightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// CreateFlight is an action method that handles HTTP POST requests to import flights.
    /// </summary>
    /// <param name="command">An instance of ImportFlightsCommand, which contains the data for the flights to be imported.</param>
    /// <returns>A Task that represents the asynchronous operation, with an IActionResult that contains the result of the operation.</returns>
    [HttpPost]
    [Route("import")]
    public async Task<IActionResult> CreateFlight([FromBody] ImportFlightsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// GetFlights is an action method that handles HTTP GET requests to retrieve flights.
    /// </summary>
    /// <param name="query">An instance of GetFlightsWithPaginationQuery, which contains the parameters for the query.</param>
    /// <returns>A Task that represents the asynchronous operation, with an IActionResult that contains the result of the operation.</returns>
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetFlights([FromQuery] GetFlightsWithPaginationQuery query)
    {
        var flights = await _mediator.Send(query);
        return Ok(flights);
    }

    /// <summary>
    /// GetFlightsWithIata is an action method that handles HTTP GET requests to retrieve flights with a specific IATA code.
    /// </summary>
    /// <param name="query">An instance of GetFlightsWithIataCodeQuery, which contains the parameters for the query.</param>
    /// <returns>A Task that represents the asynchronous operation, with an IActionResult that contains the result of the operation.</returns>
    [HttpGet]
    [Route("iata")]
    public async Task<IActionResult> GetFlightsWithIata([FromQuery] GetFlightsWithIataCodeQuery query)
    {
        var flights = await _mediator.Send(query);
        return Ok(flights);
    }
}
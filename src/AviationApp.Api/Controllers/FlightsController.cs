using AviationApp.Application.Flights.Commands;
using AviationApp.Application.Flights.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviationApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Import Flights
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("import")]
    public async Task<IActionResult> CreateFlight([FromBody] ImportFlightsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    /// <summary>
    /// Get Flights
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetFlights([FromQuery] GetFlightsWithPaginationQuery query)
    {
        var flights = await _mediator.Send(query);
        return Ok(flights);
    }
    
    /// <summary>
    /// Get Flights
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("iata")]
    public async Task<IActionResult> GetFlightsWithIata([FromQuery] GetFlightsWithIataCodeQuery query)
    {
        var flights = await _mediator.Send(query);
        return Ok(flights);
    }
}
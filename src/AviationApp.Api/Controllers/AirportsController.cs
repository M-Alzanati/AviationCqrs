using AviationApp.Application.Airports.Commands;
using AviationApp.Application.Airports.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AviationApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AirportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AirportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Import Airports
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> ImportAirports([FromBody] ImportAirportsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    /// <summary>
    /// Get Airports
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetFlights([FromQuery] GetAirportsWithPaginationQuery query)
    {
        var flights = await _mediator.Send(query);
        return Ok(flights);
    }
}
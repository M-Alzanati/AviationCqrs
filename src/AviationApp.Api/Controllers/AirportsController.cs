using AviationApp.Application.Airports.Commands;
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
    /// Import Flights
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> ImportAirports([FromBody] ImportAirportsCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
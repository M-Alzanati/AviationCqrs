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

    [HttpPost]
    public async Task<IActionResult> CreateAirport([FromBody] CreateAirportCommand command)
    {
        var airportId = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateAirport), new { id = airportId }, null);
    }
}
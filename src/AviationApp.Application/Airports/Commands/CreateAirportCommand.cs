using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using MediatR;

namespace AviationApp.Application.Airports.Commands;

public abstract class CreateAirportCommand : IRequest<int>
{
    public string AirportNumber { get; set; }
}

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, int>
{
    private readonly IAirportRepository _airportRepository;

    public CreateAirportCommandHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<int> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = new Airport
        {

        };

        await _airportRepository.Insert(airport, cancellationToken);
        return airport.Id;
    }
}
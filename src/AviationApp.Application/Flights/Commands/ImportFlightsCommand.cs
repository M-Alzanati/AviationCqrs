using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using MediatR;

namespace AviationApp.Application.Flights.Commands;

public class ImportFlightsCommand : IRequest<bool>
{
    
}

public class ImportFlightsCommandHandler(IFlightRepository flightRepository, IAviationStackService aviationStackService, IMapper mapper) : IRequestHandler<ImportFlightsCommand, bool>
{
    public async Task<bool> Handle(ImportFlightsCommand request, CancellationToken cancellationToken)
    {
        var flights = await aviationStackService.GetFlightsData(cancellationToken);

        if (flights.Data == null || !flights.Data.Any())
        {
            return false;
        }
        
        foreach (var flight in flights.Data)
        {
            await flightRepository.Insert(mapper.Map<Flight>(flight), cancellationToken);
        }

        await flightRepository.Save(cancellationToken);
        return true;
    }
}
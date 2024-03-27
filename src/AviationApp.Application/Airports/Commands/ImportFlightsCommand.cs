using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using MediatR;

namespace AviationApp.Application.Airports.Commands;

public class ImportAirportsCommand : IRequest<bool>
{
    
}

public class ImportAirportsCommandHandler(IAirportRepository airportRepository, IAviationStackService aviationStackService, IMapper mapper) : IRequestHandler<ImportAirportsCommand, bool>
{
    public async Task<bool> Handle(ImportAirportsCommand request, CancellationToken cancellationToken)
    {
        var airports = await aviationStackService.GetAirportsData(cancellationToken);

        if (airports.Data == null || !airports.Data.Any())
        {
            return false;
        }
        
        foreach (var flight in airports.Data)
        {
            await airportRepository.Insert(mapper.Map<Airport>(flight), cancellationToken);
        }

        await airportRepository.Save(cancellationToken);
        return true;
    }
}
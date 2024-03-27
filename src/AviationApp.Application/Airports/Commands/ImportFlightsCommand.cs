using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Domain.Entities;
using AviationApp.Domain.Interfaces;
using MediatR;

namespace AviationApp.Application.Airports.Commands;

public class ImportAirportsCommand : IRequest<bool>
{
    
}

public class ImportAirportsCommandHandler(IAirportService airportService) : IRequestHandler<ImportAirportsCommand, bool>
{
    public async Task<bool> Handle(ImportAirportsCommand request, CancellationToken cancellationToken)
    {
        if (await airportService.CanImportAirports(cancellationToken)) return false;
        
        await airportService.ImportAirports(cancellationToken);
        return true;
    }
}
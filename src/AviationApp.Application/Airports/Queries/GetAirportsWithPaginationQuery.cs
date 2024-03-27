using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Airports.Queries;

public class GetAirportsWithPaginationQuery : IRequest<PaginatedList<AirportDto>>, IPaginatedListQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

public class GetFlightsWithPaginationQueryHandler(IAirportService airportService, IMapper mapper)
    : IRequestHandler<GetAirportsWithPaginationQuery, PaginatedList<AirportDto>>
{
    public async Task<PaginatedList<AirportDto>> Handle(GetAirportsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var airports = await airportService.GetPaginatedAirports(request.PageNumber, request.PageSize, cancellationToken);
        var mappedResult = mapper.Map<IEnumerable<AirportDto>>(airports);
        return PaginatedList<AirportDto>.Create(mappedResult, request.PageNumber, request.PageSize);
    }
}
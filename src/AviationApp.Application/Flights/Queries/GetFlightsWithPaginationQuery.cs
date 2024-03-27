using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Flights.Queries;

public class GetFlightsWithPaginationQuery : IRequest<PaginatedList<FlightDto>>, IPaginatedListQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

public class GetFlightsWithPaginationQueryHandler(IFlightService flightService, IMapper mapper)
    : IRequestHandler<GetFlightsWithPaginationQuery, PaginatedList<FlightDto>>
{
    public async Task<PaginatedList<FlightDto>> Handle(GetFlightsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var flights = await flightService.GetPaginatedFlights(request.PageNumber, request.PageSize, cancellationToken);
        var mappedResult = mapper.Map<IEnumerable<FlightDto>>(flights);
        return PaginatedList<FlightDto>.Create(mappedResult, request.PageNumber, request.PageSize);
    }
}
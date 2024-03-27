using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Airports.Queries;

public class GetAirportsWithPaginationQuery : IRequest<ApiResponse<PaginatedList<AirportDto>>>, IPaginatedListQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

public class GetFlightsWithPaginationQueryHandler(IAirportService airportService, IMapper mapper)
    : IRequestHandler<GetAirportsWithPaginationQuery, ApiResponse<PaginatedList<AirportDto>>>
{
    public async Task<ApiResponse<PaginatedList<AirportDto>>> Handle(GetAirportsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var airports = await airportService.GetPaginatedAirports(request.PageNumber, request.PageSize, cancellationToken);
        var mappedResult = mapper.Map<IEnumerable<AirportDto>>(airports);
        return ApiResponse<PaginatedList<AirportDto>>.Create(
            PaginatedList<AirportDto>.Create(mappedResult, request.PageNumber, request.PageSize), 
            true, 
            string.Empty);
    }
}
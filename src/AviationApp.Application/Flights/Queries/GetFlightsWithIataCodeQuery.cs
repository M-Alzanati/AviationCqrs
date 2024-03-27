using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Common.Data;
using MediatR;

namespace AviationApp.Application.Flights.Queries;

public class GetFlightsWithIataCodeQuery : IRequest<ApiResponse<PaginatedList<FlightDto>>>, IPaginatedListQuery
{
    public int PageNumber { get; set; } = 1;
    
    public int PageSize { get; set; } = 20;
    
    public string? IataCode { get; set; }
}

public class GetFlightsWithIataCodeQueryHandler(IFlightService flightService, IMapper mapper)
    : IRequestHandler<GetFlightsWithIataCodeQuery, ApiResponse<PaginatedList<FlightDto>>>
{
    public async Task<ApiResponse<PaginatedList<FlightDto>>> Handle(GetFlightsWithIataCodeQuery request, CancellationToken cancellationToken)
    {
        var flights = await flightService.GetPaginatedFlights(request.IataCode, request.PageNumber, request.PageSize, cancellationToken);
        if (!flights.Any())
        {
            return ApiResponse<PaginatedList<FlightDto>>.Create(null!, false, "No data found.");
        }
        
        var mappedResult = mapper.Map<IEnumerable<FlightDto>>(flights);
        return ApiResponse<PaginatedList<FlightDto>>.Create(
            PaginatedList<FlightDto>.Create(mappedResult, request.PageNumber, request.PageSize), 
            true, 
            "Data retrieved successfully.");
    }
}
using AutoMapper;
using AviationApp.Common.Data;
using AviationApp.Domain.Services;
using MediatR;

namespace AviationApp.Application.Flights.Queries;

/// <summary>
/// GetFlightsWithPaginationQuery is a query class that implements IRequest interface.
/// It is used to get a paginated list of flights.
/// </summary>
public class GetFlightsWithPaginationQuery : IRequest<ApiResponse<PaginatedList<FlightDto>>>, IPaginatedListQuery
{
    /// <summary>
    /// PageNumber is the number of the page to be retrieved.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// PageSize is the number of items per page.
    /// </summary>
    public int PageSize { get; set; } = 20;
}

/// <summary>
/// GetFlightsWithPaginationQueryHandler is a handler class for GetFlightsWithPaginationQuery.
/// It implements IRequestHandler interface and handles the execution of the query.
/// </summary>
public class GetFlightsWithPaginationQueryHandler(IFlightService flightService, IMapper mapper)
    : IRequestHandler<GetFlightsWithPaginationQuery, ApiResponse<PaginatedList<FlightDto>>>
{
    /// <summary>
    /// Handle is a method that handles the execution of the GetFlightsWithPaginationQuery.
    /// It retrieves a paginated list of flights and maps them to FlightDto objects.
    /// </summary>
    /// <param name="request">An instance of GetFlightsWithPaginationQuery, which is the query to be executed.</param>
    /// <param name="cancellationToken">A CancellationToken that can be used to cancel the operation.</param>
    /// <returns>A Task that represents the asynchronous operation, with an ApiResponse<PaginatedList<FlightDto>> that contains the result of the operation.</returns>
    public async Task<ApiResponse<PaginatedList<FlightDto>>> Handle(GetFlightsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var flights = await flightService.GetPaginatedFlights(request.PageNumber, request.PageSize, cancellationToken);
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
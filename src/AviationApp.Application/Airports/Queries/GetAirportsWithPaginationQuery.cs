using AutoMapper;
using AviationApp.Common.Data;
using AviationApp.Domain.Services;
using MediatR;

namespace AviationApp.Application.Airports.Queries;

/// <summary>
/// GetAirportsWithPaginationQuery is a query class that implements IRequest interface.
/// It is used to get a paginated list of airports.
/// </summary>
public class GetAirportsWithPaginationQuery : IRequest<ApiResponse<PaginatedList<AirportDto>>>, IPaginatedListQuery
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
/// GetFlightsWithPaginationQueryHandler is a handler class for GetAirportsWithPaginationQuery.
/// It implements IRequestHandler interface and handles the execution of the query.
/// </summary>
public class GetFlightsWithPaginationQueryHandler(IAirportService airportService, IMapper mapper)
    : IRequestHandler<GetAirportsWithPaginationQuery, ApiResponse<PaginatedList<AirportDto>>>
{
    /// <summary>
    /// Handle is a method that handles the execution of the GetAirportsWithPaginationQuery.
    /// It retrieves a paginated list of airports and maps them to AirportDto objects.
    /// </summary>
    /// <param name="request">An instance of GetAirportsWithPaginationQuery, which is the query to be executed.</param>
    /// <param name="cancellationToken">A CancellationToken that can be used to cancel the operation.</param>
    /// <returns>A Task that represents the asynchronous operation, with an ApiResponse<PaginatedList<AirportDto>> that contains the result of the operation.</returns>
    public async Task<ApiResponse<PaginatedList<AirportDto>>> Handle(GetAirportsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var airports = await airportService.GetPaginatedAirports(request.PageNumber, request.PageSize, cancellationToken);
        if (!airports.Any())
        {
            return ApiResponse<PaginatedList<AirportDto>>.Create(null!, false, "No data found.");
        }

        var mappedResult = mapper.Map<IEnumerable<AirportDto>>(airports);
        return ApiResponse<PaginatedList<AirportDto>>.Create(
            PaginatedList<AirportDto>.Create(mappedResult, request.PageNumber, request.PageSize),
            true,
            "Data retrieved successfully.");
    }
}
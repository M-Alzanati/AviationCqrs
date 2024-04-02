using AutoMapper;
using AviationApp.Common.Data;
using AviationApp.Domain.Services;
using FluentValidation;
using MediatR;

namespace AviationApp.Application.Flights.Queries;

/// <summary>
/// GetFlightsWithIataCodeQuery is a query class that implements IRequest interface.
/// It is used to get a paginated list of flights with a specific IATA code.
/// </summary>
public class GetFlightsWithIataCodeQuery : IRequest<ApiResponse<PaginatedList<FlightDto>>>, IPaginatedListQuery
{
    /// <summary>
    /// PageNumber is the number of the page to be retrieved.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// PageSize is the number of items per page.
    /// </summary>
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// IataCode is the IATA code of the flights to be retrieved.
    /// </summary>
    public string? IataCode { get; set; }
}

/// <summary>
/// GetFlightsWithIataCodeQueryValidator is a validator class for GetFlightsWithIataCodeQuery.
/// It inherits from AbstractValidator<T> where T is GetFlightsWithIataCodeQuery.
/// </summary>
public class GetFlightsWithIataCodeQueryValidator : AbstractValidator<GetFlightsWithIataCodeQuery>
{
    /// <summary>
    /// The constructor of GetFlightsWithIataCodeQueryValidator.
    /// It defines a rule for the IataCode property of GetFlightsWithIataCodeQuery to not be empty.
    /// </summary>
    public GetFlightsWithIataCodeQueryValidator()
    {
        RuleFor(x => x.IataCode)
            .NotEmpty()
            .WithMessage("IataCode must not be empty.");
    }
}

/// <summary>
/// GetFlightsWithIataCodeQueryHandler is a handler class for GetFlightsWithIataCodeQuery.
/// It implements IRequestHandler interface and handles the execution of the query.
/// </summary>
public class GetFlightsWithIataCodeQueryHandler(IFlightService flightService, IMapper mapper)
    : IRequestHandler<GetFlightsWithIataCodeQuery, ApiResponse<PaginatedList<FlightDto>>>
{
    /// <summary>
    /// Handle is a method that handles the execution of the GetFlightsWithIataCodeQuery.
    /// It retrieves a paginated list of flights with a specific IATA code and maps them to FlightDto objects.
    /// </summary>
    /// <param name="request">An instance of GetFlightsWithIataCodeQuery, which is the query to be executed.</param>
    /// <param name="cancellationToken">A CancellationToken that can be used to cancel the operation.</param>
    /// <returns>A Task that represents the asynchronous operation, with an ApiResponse<PaginatedList<FlightDto>> that contains the result of the operation.</returns>
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
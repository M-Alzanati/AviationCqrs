using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Application.Flights.Queries;
using AviationApp.Domain.Entities;
using Moq;

namespace AviationApp.UnitTests.Flights.Queries;

public class GetFlightsWithPaginationQueryTests
{
    [Test]
    public async Task Handle_WhenFlightsExist_ReturnsDataRetrievedSuccessfully()
    {
        var mockFlightService = new Mock<IFlightService>();
        var mockMapper = new Mock<IMapper>();
        var flights = new List<Flight> { new Flight(), new Flight() };
        mockFlightService.Setup(service => service.GetPaginatedFlights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(flights);
        var mappedFlights = new List<FlightDto> { new FlightDto(), new FlightDto() };
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<FlightDto>>(flights)).Returns(mappedFlights);

        var handler = new GetFlightsWithPaginationQueryHandler(mockFlightService.Object, mockMapper.Object);

        var result = await handler.Handle(new GetFlightsWithPaginationQuery(), new CancellationToken());

        Assert.IsTrue(result.Success);
        Assert.AreEqual("Data retrieved successfully.", result.Message);
    }

    [Test]
    public async Task Handle_WhenNoFlightsExist_ReturnsNoDataFound()
    {
        var mockFlightService = new Mock<IFlightService>();
        var mockMapper = new Mock<IMapper>();
        var flights = new List<Flight>();
        mockFlightService.Setup(service => service.GetPaginatedFlights(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(flights);

        var handler = new GetFlightsWithPaginationQueryHandler(mockFlightService.Object, mockMapper.Object);

        var result = await handler.Handle(new GetFlightsWithPaginationQuery(), new CancellationToken());

        Assert.IsFalse(result.Success);
        Assert.AreEqual("No data found.", result.Message);
    }
}
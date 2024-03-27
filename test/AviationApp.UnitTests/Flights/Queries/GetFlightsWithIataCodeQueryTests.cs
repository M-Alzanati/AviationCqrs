using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Application.Flights.Queries;
using AviationApp.Domain.Entities;
using Moq;

namespace AviationApp.UnitTests.Flights.Queries;

public class GetFlightsWithIataCodeQueryTests
{
    [Test]
    public async Task Handle_WhenFlightsWithIataCodeExist_ReturnsDataRetrievedSuccessfully()
    {
        var mockFlightService = new Mock<IFlightService>();
        var mockMapper = new Mock<IMapper>();
        var flights = new List<Flight> { new Flight(), new Flight() };
        mockFlightService.Setup(service => service.GetPaginatedFlights(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(flights);

        var handler = new GetFlightsWithIataCodeQueryHandler(mockFlightService.Object, mockMapper.Object);

        var result = await handler.Handle(new GetFlightsWithIataCodeQuery { IataCode = "XYZ" }, new CancellationToken());

        Assert.IsTrue(result.Success);
        Assert.That(result.Message, Is.EqualTo("Data retrieved successfully."));
    }

    [Test]
    public async Task Handle_WhenNoFlightsWithIataCodeExist_ReturnsNoDataFound()
    {
        var mockFlightService = new Mock<IFlightService>();
        var mockMapper = new Mock<IMapper>();
        var flights = new List<Flight>();
        mockFlightService.Setup(service => service.GetPaginatedFlights(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(flights);

        var handler = new GetFlightsWithIataCodeQueryHandler(mockFlightService.Object, mockMapper.Object);

        var result = await handler.Handle(new GetFlightsWithIataCodeQuery { IataCode = "XYZ" }, new CancellationToken());

        Assert.IsFalse(result.Success);
        Assert.That(result.Message, Is.EqualTo("No data found."));
    }
}
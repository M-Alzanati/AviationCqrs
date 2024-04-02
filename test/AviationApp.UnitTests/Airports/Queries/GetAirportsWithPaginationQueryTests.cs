using AutoMapper;
using AviationApp.Application.Airports.Queries;
using AviationApp.Domain.Entities;
using AviationApp.Domain.Services;
using Moq;

namespace AviationApp.UnitTests.Airports.Queries;

public class GetAirportsWithPaginationQueryTests
{
    [Test]
    public async Task Handle_WhenAirportsExist_ReturnsDataRetrievedSuccessfully()
    {
        var mockAirportService = new Mock<IAirportService>();
        var mockMapper = new Mock<IMapper>();
        var airports = new List<Airport> { new Airport(), new Airport() };
        mockAirportService.Setup(service => service.GetPaginatedAirports(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(airports);

        var handler = new GetFlightsWithPaginationQueryHandler(mockAirportService.Object, mockMapper.Object);

        var result = await handler.Handle(new GetAirportsWithPaginationQuery(), new CancellationToken());

        Assert.IsTrue(result.Success);
        Assert.That(result.Message, Is.EqualTo("Data retrieved successfully."));
    }

    [Test]
    public async Task Handle_WhenNoAirportsExist_ReturnsNoDataFound()
    {
        var mockAirportService = new Mock<IAirportService>();
        var mockMapper = new Mock<IMapper>();
        var airports = new List<Airport>();
        mockAirportService.Setup(service => service.GetPaginatedAirports(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync(airports);

        var handler = new GetFlightsWithPaginationQueryHandler(mockAirportService.Object, mockMapper.Object);

        var result = await handler.Handle(new GetAirportsWithPaginationQuery(), new CancellationToken());

        Assert.IsFalse(result.Success);
        Assert.That(result.Message, Is.EqualTo("No data found."));
    }
}
using AutoMapper;
using AviationApp.Application.Common.Interface;
using AviationApp.Application.Flights.Commands;
using AviationApp.Common.Clients.AviationStack;
using AviationApp.Domain.Interfaces;
using Moq;
using Flight = AviationApp.Domain.Entities.Flight;

namespace AviationApp.UnitTests.Flights.Commands;

public class ImportFlightsCommandTests
{
    [Test]
    public async Task Handle_GivenValidRequest_ShouldReturnTrue()
    {
        // Arrange
        var mockFlightRepository = new Mock<IFlightRepository>();
        var mockAviationStackService = new Mock<IAviationStackService>();
        var mockMapper = new Mock<IMapper>();

        mockAviationStackService.Setup(service => service.GetFlightsData(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FlightData { Data = new List<FlightInfo> { new() } });

        var handler = new ImportFlightsCommandHandler(mockFlightRepository.Object, mockAviationStackService.Object,
            mockMapper.Object);
        var command = new ImportFlightsCommand { Count = 5 };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
        mockFlightRepository.Verify(repo => repo.Insert(It.IsAny<Flight>(), It.IsAny<CancellationToken>()),
            Times.AtLeastOnce());
        mockFlightRepository.Verify(repo => repo.Save(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Test]
    public async Task Handle_GivenEmptyFlightData_ShouldNotInsertFlights()
    {
        // Arrange
        var mockFlightRepository = new Mock<IFlightRepository>();
        var mockAviationStackService = new Mock<IAviationStackService>();
        var mockMapper = new Mock<IMapper>();

        mockAviationStackService.Setup(service => service.GetFlightsData(It.IsAny<CancellationToken>()))
            .ReturnsAsync(new FlightData() { Data = new List<FlightInfo>() });

        var handler = new ImportFlightsCommandHandler(mockFlightRepository.Object, mockAviationStackService.Object,
            mockMapper.Object);
        var command = new ImportFlightsCommand { Count = 5 };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result);
        mockFlightRepository.Verify(repo => repo.Insert(It.IsAny<Flight>(), It.IsAny<CancellationToken>()),
            Times.Never());
        mockFlightRepository.Verify(repo => repo.Save(It.IsAny<CancellationToken>()), Times.Never());
    }
}
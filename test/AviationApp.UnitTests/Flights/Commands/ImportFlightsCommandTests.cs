using AviationApp.Application.Common.Interface;
using AviationApp.Application.Flights.Commands;
using Moq;

namespace AviationApp.UnitTests.Flights.Commands;

public class ImportFlightsCommandTests
{
    [Test]
    public async Task Handle_WhenFlightsCanBeImported_ReturnsDataImportedSuccessfully()
    {
        var mockFlightService = new Mock<IFlightService>();
        mockFlightService.Setup(service => service.CanImportFlights(It.IsAny<CancellationToken>())).ReturnsAsync(false);

        var handler = new ImportFlightsCommandHandler(mockFlightService.Object);

        var result = await handler.Handle(new ImportFlightsCommand(), new CancellationToken());

        Assert.IsTrue(result.Success);
        Assert.That(result.Message, Is.EqualTo("Data Imported successfully"));
    }

    [Test]
    public async Task Handle_WhenFlightsCannotBeImported_ReturnsDataAlreadyImported()
    {
        var mockFlightService = new Mock<IFlightService>();
        mockFlightService.Setup(service => service.CanImportFlights(It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var handler = new ImportFlightsCommandHandler(mockFlightService.Object);

        var result = await handler.Handle(new ImportFlightsCommand(), new CancellationToken());

        Assert.IsFalse(result.Success);
        Assert.That(result.Message, Is.EqualTo("Data already imported"));
    }
}
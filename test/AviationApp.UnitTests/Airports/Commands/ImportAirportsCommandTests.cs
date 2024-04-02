using AviationApp.Application.Airports.Commands;
using AviationApp.Domain.Interfaces;
using Moq;

namespace AviationApp.UnitTests.Airports.Commands;

public class ImportAirportsCommandTests
{
    [Test]
    public async Task Handle_WhenCanImportAirports_ReturnsDataImportedSuccessfully()
    {
        // Arrange
        var mockAirportService = new Mock<IAirportService>();
        mockAirportService.Setup(service => service.CanImportAirports(It.IsAny<CancellationToken>())).ReturnsAsync(false);

        var handler = new ImportAirportsCommandHandler(mockAirportService.Object);

        // Act
        var result = await handler.Handle(new ImportAirportsCommand(), new CancellationToken());

        // Assert
        Assert.IsTrue(result.Success);
        Assert.That(result.Message, Is.EqualTo("Data Imported successfully"));
    }

    [Test]
    public async Task Handle_WhenCannotImportAirports_ReturnsDataAlreadyImported()
    {
        // Arrange
        var mockAirportService = new Mock<IAirportService>();
        mockAirportService.Setup(service => service.CanImportAirports(It.IsAny<CancellationToken>())).ReturnsAsync(true);

        var handler = new ImportAirportsCommandHandler(mockAirportService.Object);

        // Act
        var result = await handler.Handle(new ImportAirportsCommand(), new CancellationToken());

        // Assert
        Assert.IsFalse(result.Success);
        Assert.That(result.Message, Is.EqualTo("Data already imported"));
    }
}
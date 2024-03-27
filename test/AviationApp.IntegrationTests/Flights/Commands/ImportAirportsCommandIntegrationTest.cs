using AviationApp.Application.Airports.Commands;
using Microsoft.EntityFrameworkCore;
using NUnit;

namespace AviationApp.IntegrationTests.Flights.Commands;

public class ImportAirportsCommandIntegrationTest : BaseIntegrationTest
{
    [Test]
    public async Task ImportAirportsCommand_ShouldImportAirports()
    {
        // Arrange
        var optionsBuilder = new DbContextOptionsBuilder<YourDbContext>()
            .UseMySql(MySqlContainer.ConnectionString);
        var context = new YourDbContext(optionsBuilder.Options);
        var mediator = // set up your mediator here
            var command = new ImportAirportsCommand
        {
            // set up your command data here
        };

        // Act
        var handler = new ImportAirportsCommandHandler(context, mediator);
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        // Verify the results here
    }
}
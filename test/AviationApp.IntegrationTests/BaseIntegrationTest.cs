using Testcontainers.MySql;

namespace AviationApp.IntegrationTests.Flights.Commands;

public abstract class BaseIntegrationTest
{
    protected readonly MySqlContainer MySqlContainer = new MySqlBuilder()
        .WithImage("mysql:8.0")
        .Build();

    public async Task InitializeAsync()
    {
        await MySqlContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await MySqlContainer.StopAsync();
    }
    
    [OneTimeSetUp]
    protected virtual async Task RunBeforeTests()
    {
        await InitializeAsync();
    }
    
    [TearDown]
    protected virtual async Task RunAfterTests()
    {
        await DisposeAsync();
    }
}
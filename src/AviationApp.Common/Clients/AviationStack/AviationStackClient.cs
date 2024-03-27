using AviationApp.Common.Serializer;
using Microsoft.Extensions.Logging;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace AviationApp.Common.Clients.AviationStack;

public class AviationStackClient : AbstractRestClient, IAviationStackClient
{
    private string? _apiKey = null!;
    
    public AviationStackClient(IConfiguration configuration, ILogger<AbstractRestClient> logger) : base(
        baseUrl: new Uri(configuration["AviationStack:apiUrl"] ?? string.Empty),
        logger: logger)
    {
        _apiKey = configuration["AviationStack:apiKey"];
    }

    protected override IHttpSerializer GetSerializerInstance()
    {
        return new JsonSnakeHttpSerializer();
    }
    
    public async Task<FlightData> GetFlightsData(CancellationToken cancellationToken)
    {
        return await Get<FlightData>($"flights?access_key={_apiKey}", cancellationToken);
    }
    
    public async Task<AirportData> GetAirportsData(CancellationToken cancellationToken)
    {
        return await Get<AirportData>($"airports?access_key={_apiKey}", cancellationToken);
    }
}
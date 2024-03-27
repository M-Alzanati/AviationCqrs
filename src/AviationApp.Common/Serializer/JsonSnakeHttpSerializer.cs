using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AviationApp.Common.Serializer;

public class JsonSnakeHttpSerializer : IHttpSerializer
{
    private readonly JsonSerializerSettings _snakeCase = new()
    {
        ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };
    public async Task<TR> DeserializeResponse<TR>(HttpContent response)
    {
        var responseString = await response.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TR>(responseString, _snakeCase)!;
    }

    public HttpContent SerializeRequest<T>(T request)
    {
        var body = new StringContent(JsonConvert.SerializeObject(request, _snakeCase));
        body.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        return body;
    }
}
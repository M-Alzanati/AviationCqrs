namespace AviationApp.Common.Serializer;

public interface IHttpSerializer
{
    HttpContent SerializeRequest<T>(T request);
    
    Task<T> DeserializeResponse<T>(HttpContent response);
}
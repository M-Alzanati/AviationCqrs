using System.Net;
using AviationApp.Common.Serializer;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace AviationApp.Common.Clients;

public abstract class AbstractRestClient
{
    protected readonly ILogger Logger;
    
    public Uri BaseUrl { get; }
    
    protected readonly HttpClient HttpClient;
    
    protected IAsyncPolicy<HttpResponseMessage> AsyncPolicy = null!;
    
    protected IAsyncPolicy<HttpResponseMessage> RequestHandlingPolicy => AsyncPolicy ??= GetRequestHandlingPolicyInstance();
    
    protected IHttpSerializer HttpSerializer = null!;
    
    protected IHttpSerializer Serializer => HttpSerializer ??= GetSerializerInstance();
    
    protected AbstractRestClient(Uri baseUrl, ILogger logger)
    {
        BaseUrl = baseUrl;
        Logger = logger;

        HttpClient = new()
        {
            BaseAddress = BaseUrl
        };
    }
    
    protected virtual IAsyncPolicy<HttpResponseMessage> GetRequestHandlingPolicyInstance()
    {
        return Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .OrResult(r => r.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(
                    medianFirstRetryDelay: TimeSpan.FromSeconds(1),
                    retryCount: 5
             ));
    }
    
    protected virtual Task PrepareClient()
    {
        return Task.CompletedTask;
    }
    
    protected abstract IHttpSerializer GetSerializerInstance();
    
    protected virtual async Task<T> Get<T>(string resource, CancellationToken cancellationToken = default)
    {
        await PrepareClient();

        var result = await RequestHandlingPolicy.ExecuteAsync(async () => await HttpClient.GetAsync(resource, cancellationToken));

        await EnsureSuccessStatusCode(result);
        return await Serializer.DeserializeResponse<T>(result.Content);
    }
    
    protected virtual async Task Delete(string resource, CancellationToken cancellationToken = default)
    {
        await PrepareClient();

        var result = await RequestHandlingPolicy.ExecuteAsync(async () => await HttpClient.DeleteAsync(resource, cancellationToken));

        await EnsureSuccessStatusCode(result);
    }
    
    protected async Task<R> Post<T, R>(string resource, T request)
    {
        return await Post<R>(resource, Serializer.SerializeRequest(request));
    }

    private async Task<R> Post<R>(string resource, HttpContent? request = null, CancellationToken cancellationToken = default)
    {
        await PrepareClient();

        var result = await RequestHandlingPolicy.ExecuteAsync(async () => await HttpClient.PostAsync(resource, request, cancellationToken));

        await EnsureSuccessStatusCode(result);
        return await Serializer.DeserializeResponse<R>(result.Content);
    }
    
    protected async Task<R> Put<T, R>(string resource, T request)
    {
        return await Put<R>(resource, Serializer.SerializeRequest(request));
    }

    private async Task<R> Put<R>(string resource, HttpContent? request = null, CancellationToken cancellationToken = default)
    {
        await PrepareClient();

        var result = await RequestHandlingPolicy.ExecuteAsync(async () => await HttpClient.PutAsync(resource, request, cancellationToken));

        await EnsureSuccessStatusCode(result);
        return await Serializer.DeserializeResponse<R>(result.Content);
    }
    
    protected virtual Task EnsureSuccessStatusCode(HttpResponseMessage? responseMessage)
    {
        responseMessage?.EnsureSuccessStatusCode();

        return Task.CompletedTask;
    }
}
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Notion.HttpClients.Abstract;
using Soenneker.Notion.OpenApiClientUtil.Abstract;
using Soenneker.Notion.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Notion.OpenApiClientUtil;

///<inheritdoc cref="INotionOpenApiClientUtil"/>
public sealed class NotionOpenApiClientUtil : INotionOpenApiClientUtil
{
    private readonly AsyncSingleton<NotionOpenApiClient> _client;

    public NotionOpenApiClientUtil(INotionOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<NotionOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Notion:ApiKey");
            string authHeaderValueTemplate = configuration["Notion:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new NotionOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<NotionOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}

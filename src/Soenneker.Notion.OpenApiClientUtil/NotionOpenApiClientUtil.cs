using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Notion.HttpClients.Abstract;
using Soenneker.Notion.OpenApiClientUtil.Abstract;
using Soenneker.Notion.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Notion.OpenApiClientUtil;

public sealed class NotionOpenApiClientUtil : INotionOpenApiClientUtil
{
    private readonly AsyncSingleton<NotionOpenApiClient> _client;

    public NotionOpenApiClientUtil(INotionOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<NotionOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

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

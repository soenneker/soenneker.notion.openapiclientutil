using Soenneker.Notion.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Notion.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface INotionOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<NotionOpenApiClient> Get(CancellationToken cancellationToken = default);
}

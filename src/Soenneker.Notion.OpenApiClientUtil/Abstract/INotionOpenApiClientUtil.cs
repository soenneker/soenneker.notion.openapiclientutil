using Soenneker.Notion.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Notion.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Notion API client backed by the configured HTTP provider.
/// </summary>
public interface INotionOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Notion client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Notion client.</returns>
    ValueTask<NotionOpenApiClient> Get(CancellationToken cancellationToken = default);
}

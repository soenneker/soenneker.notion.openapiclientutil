using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Notion.HttpClients.Registrars;
using Soenneker.Notion.OpenApiClientUtil.Abstract;

namespace Soenneker.Notion.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class NotionOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="NotionOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddNotionOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddNotionOpenApiHttpClientAsSingleton()
                .TryAddSingleton<INotionOpenApiClientUtil, NotionOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="NotionOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddNotionOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddNotionOpenApiHttpClientAsSingleton()
                .TryAddScoped<INotionOpenApiClientUtil, NotionOpenApiClientUtil>();

        return services;
    }
}

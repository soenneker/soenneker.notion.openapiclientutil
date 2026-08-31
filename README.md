[![](https://img.shields.io/nuget/v/soenneker.notion.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.notion.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.notion.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.notion.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.notion.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.notion.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.notion.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.notion.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Notion.OpenApiClientUtil

Provides a configured Notion API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Notion.OpenApiClientUtil
```

## Configuration

```json
{
  "Notion": {
    "ApiKey": "your-integration-token"
  }
}
```

## Usage

```csharp
using Soenneker.Notion.OpenApiClientUtil.Abstract;
using Soenneker.Notion.OpenApiClientUtil.Registrars;

services.AddNotionOpenApiClientUtilAsSingleton();

INotionOpenApiClientUtil notion = serviceProvider
    .GetRequiredService<INotionOpenApiClientUtil>();

var client = await notion.Get(cancellationToken);
var currentUser = await client.V1.Users.Me.GetAsync(cancellationToken: cancellationToken);
```

The underlying HTTP provider supplies both authentication and the Notion API version header expected by the generated schema.

Use `AddNotionOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.

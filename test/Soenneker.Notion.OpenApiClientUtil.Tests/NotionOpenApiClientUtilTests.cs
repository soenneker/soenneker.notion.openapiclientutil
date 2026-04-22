using Soenneker.Notion.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Notion.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class NotionOpenApiClientUtilTests : HostedUnitTest
{
    private readonly INotionOpenApiClientUtil _openapiclientutil;

    public NotionOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<INotionOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}

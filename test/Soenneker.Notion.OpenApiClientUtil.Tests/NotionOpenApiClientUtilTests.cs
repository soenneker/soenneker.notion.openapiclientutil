using Soenneker.Notion.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Notion.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class NotionOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly INotionOpenApiClientUtil _openapiclientutil;

    public NotionOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<INotionOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}

using Soenneker.Tests.HostedUnit;

namespace Soenneker.LaunchDarkly.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LaunchDarklyOpenApiClientTests : HostedUnitTest
{
    public LaunchDarklyOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}

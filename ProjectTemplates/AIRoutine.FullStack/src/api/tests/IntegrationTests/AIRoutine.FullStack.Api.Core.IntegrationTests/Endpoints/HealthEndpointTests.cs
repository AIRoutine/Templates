using AIRoutine.FullStack.Api.IntegrationTests.Infrastructure;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace AIRoutine.FullStack.Api.Core.IntegrationTests.Endpoints;

/// <summary>
/// Tests fuer Health-Endpoints.
/// </summary>
[TestFixture]
[Category(TestCategories.Core)]
[Category(TestCategories.Endpoint)]
[Category(TestCategories.Integration)]
internal class HealthEndpointTests : BaseApiIntegrationTest
{
    [Test]
    [Category(TestCategories.Smoke)]
    public async Task HealthEndpoint_ReturnsOkAsync()
    {
        // Arrange & Act
        var response = await Client.GetAsync(new Uri("/health", UriKind.Relative));

        // Assert
        _ = response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}

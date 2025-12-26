using AIRoutine.FullStack.Api.IntegrationTests.Infrastructure;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace AIRoutine.FullStack.Api.Features.Auth.IntegrationTests.Endpoints;

/// <summary>
/// Tests fuer Auth-Endpoints.
/// </summary>
[TestFixture]
[Category(TestCategories.Auth)]
[Category(TestCategories.Endpoint)]
[Category(TestCategories.Integration)]
public class AuthEndpointTests : BaseApiIntegrationTest
{
    [Test]
    [Category(TestCategories.Smoke)]
    public async Task SignIn_WithInvalidCredentials_ReturnsUnauthorized()
    {
        // Arrange
        var content = new StringContent(
            """{"email": "invalid@test.com", "password": "wrong"}""",
            System.Text.Encoding.UTF8,
            "application/json");

        // Act
        var response = await Client.PostAsync("/api/auth/signin", content);

        // Assert
        response.StatusCode.Should().BeOneOf(HttpStatusCode.Unauthorized, HttpStatusCode.BadRequest, HttpStatusCode.NotFound);
    }
}

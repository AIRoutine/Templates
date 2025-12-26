using AIRoutine.FullStack.Api.UnitTests.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AIRoutine.FullStack.Api.Features.Auth.UnitTests.Handlers;

/// <summary>
/// Tests fuer SignInHandler.
/// </summary>
[TestFixture]
[Category(TestCategories.Auth)]
[Category(TestCategories.Handler)]
[Category(TestCategories.Unit)]
public class SignInHandlerTests : BaseApiUnitTest
{
    [Test]
    [Category(TestCategories.Smoke)]
    public void Handle_WithValidCredentials_ReturnsToken()
    {
        // Arrange & Act & Assert
        // TODO: Implementiere nach Handler-Implementierung
        true.Should().BeTrue("Placeholder-Test");
    }

    [Test]
    public void Handle_WithInvalidCredentials_ReturnsError()
    {
        // Arrange & Act & Assert
        // TODO: Implementiere nach Handler-Implementierung
        true.Should().BeTrue("Placeholder-Test");
    }
}

using AIRoutine.FullStack.UnitTests.Infrastructure;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AIRoutine.FullStack.Features.Auth.UnitTests.Services;

/// <summary>
/// Tests fuer AuthService.
/// </summary>
[TestFixture]
[Category(TestCategories.Auth)]
[Category(TestCategories.Unit)]
public class AuthServiceTests : BaseUnitTest
{
    [Test]
    [Category(TestCategories.Smoke)]
    public void AuthService_CanBeCreated()
    {
        // Arrange & Act & Assert
        // TODO: Implementiere nach AuthService-Interface
        true.Should().BeTrue("Placeholder-Test");
    }
}

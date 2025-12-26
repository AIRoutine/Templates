using AIRoutine.FullStack.Core.Startup;
using AIRoutine.FullStack.Features.Auth.Configuration;
using AIRoutine.FullStack.IntegrationTests.Infrastructure;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace AIRoutine.FullStack.Features.Auth.IntegrationTests.Flows;

/// <summary>
/// Integration-Tests fuer den Login-Flow.
/// </summary>
[TestFixture]
[Category(TestCategories.Auth)]
[Category(TestCategories.Integration)]
public class LoginFlowTests : BaseIntegrationTest
{
    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddAppServices();
        services.AddAuthFeature();
    }

    [Test]
    [Category(TestCategories.Smoke)]
    public void LoginFlow_ServicesAreRegistered()
    {
        // Assert
        Services.Should().NotBeEmpty();
    }

    [Test]
    public void LoginFlow_CanExecute()
    {
        // Arrange & Act & Assert
        // TODO: Implementiere nach Auth-Service-Implementierung
        true.Should().BeTrue("Placeholder-Test");
    }
}

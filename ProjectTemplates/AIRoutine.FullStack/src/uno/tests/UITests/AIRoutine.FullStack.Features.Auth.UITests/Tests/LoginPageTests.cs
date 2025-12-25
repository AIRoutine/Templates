using AIRoutine.FullStack.Features.Auth.UITests.PageObjects;
using AIRoutine.FullStack.UITests.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AIRoutine.FullStack.Features.Auth.UITests.Tests;

/// <summary>
/// Tests fuer die LoginPage.
/// Diese Tests setzen voraus, dass die App im nicht-authentifizierten Zustand startet.
/// </summary>
[TestFixture]
[Category(TestCategories.Auth)]
[Category(TestCategories.Feature)]
public class LoginPageTests : BaseTestFixture
{
    private LoginPageObject _loginPage = null!;

    protected override void OnSetUp()
    {
        _loginPage = new LoginPageObject(App);

        // Nur weitermachen wenn LoginPage angezeigt wird
        // In einer konfigurierten Auth-App wird die LoginPage beim Start angezeigt
        if (_loginPage.IsDisplayed())
        {
            _loginPage.WaitForPage();
        }
    }

    [Test]
    [Category(TestCategories.Smoke)]
    public void LoginPage_IsDisplayed_WhenNotAuthenticated()
    {
        // Dieser Test setzt voraus, dass die App ohne Auth-Token startet

        // Assert
        _loginPage.IsDisplayed().Should().BeTrue(
            "LoginPage sollte angezeigt werden wenn nicht authentifiziert");
    }

    [Test]
    public void LoginPage_Displays_WelcomeMessage()
    {
        // Assert
        _loginPage.GetWelcomeText().Should().Contain("Welcome");
    }

    [Test]
    public void LoginPage_Displays_Subtitle()
    {
        // Assert
        _loginPage.GetSubtitleText().Should().NotBeEmpty();
    }

    [Test]
    [Category(TestCategories.Smoke)]
    public void LoginPage_HasSignInButton()
    {
        // Assert
        _loginPage.IsSignInButtonEnabled().Should().BeTrue();
    }

    [Test]
    public void LoginPage_ShowsAllProviderButtons()
    {
        // Assert
        _loginPage.AreAllProviderButtonsVisible().Should().BeTrue(
            "Alle Provider-Buttons (Microsoft, Google, Apple) sollten sichtbar sein");
    }

    [Test]
    public void LoginPage_NoErrorOnInitialLoad()
    {
        // Assert
        _loginPage.HasError().Should().BeFalse(
            "Es sollte kein Fehler beim initialen Laden angezeigt werden");
    }

    [Test]
    public void LoginPage_HasNavigationBar()
    {
        // Assert
        var title = _loginPage.GetNavigationTitle();
        title.Should().NotBeEmpty("NavigationBar sollte einen Titel haben");
    }
}

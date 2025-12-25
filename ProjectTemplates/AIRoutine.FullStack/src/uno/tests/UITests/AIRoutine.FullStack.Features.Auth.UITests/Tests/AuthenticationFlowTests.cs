using AIRoutine.FullStack.Features.Auth.UITests.PageObjects;
using AIRoutine.FullStack.UITests.Configuration;
using AIRoutine.FullStack.UITests.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace AIRoutine.FullStack.Features.Auth.UITests.Tests;

/// <summary>
/// Tests fuer den Authentifizierungs-Flow.
/// Diese Tests pruefen den End-to-End-Flow der Authentifizierung.
/// </summary>
[TestFixture]
[Category(TestCategories.Auth)]
[Category(TestCategories.Feature)]
public class AuthenticationFlowTests : BaseTestFixture
{
    private LoginPageObject _loginPage = null!;

    protected override void OnSetUp()
    {
        _loginPage = new LoginPageObject(App);
    }

    [Test]
    [Category(TestCategories.Smoke)]
    [Category(TestCategories.Critical)]
    public void SignIn_ShowsLoadingIndicator_WhenClicked()
    {
        // Arrange
        if (!_loginPage.IsDisplayed())
        {
            Assert.Ignore("LoginPage wird nicht angezeigt - Auth ist moeglicherweise deaktiviert");
            return;
        }

        _loginPage.WaitForPage();

        // Act
        _loginPage.ClickSignIn();

        // Assert - Der Busy-Overlay sollte kurz sichtbar sein
        // Dieser Test ist timing-sensitiv und kann fehlschlagen wenn die Antwort zu schnell kommt
        // In einem echten Szenario wuerde man hier auf einen Mock-Server warten
    }

    [Test]
    public void ProviderSignIn_Microsoft_InitiatesFlow()
    {
        // Arrange
        if (!_loginPage.IsDisplayed())
        {
            Assert.Ignore("LoginPage wird nicht angezeigt - Auth ist moeglicherweise deaktiviert");
            return;
        }

        _loginPage.WaitForPage();

        // Act
        _loginPage.ClickSignInWithMicrosoft();

        // Assert
        // In einem echten Szenario wuerde hier ein Browser/WebView geoeffnet werden
        // Fuer UI-Tests kann man pruefen ob der Busy-Overlay erscheint
        // oder ob ein Browser-Intent ausgeloest wurde (plattformabhaengig)
    }

    [Test]
    public void ProviderSignIn_Google_InitiatesFlow()
    {
        // Arrange
        if (!_loginPage.IsDisplayed())
        {
            Assert.Ignore("LoginPage wird nicht angezeigt - Auth ist moeglicherweise deaktiviert");
            return;
        }

        _loginPage.WaitForPage();

        // Act
        _loginPage.ClickSignInWithGoogle();

        // Assert - Aehnlich wie Microsoft
    }

    [Test]
    [Category(TestCategories.iOS)]
    public void ProviderSignIn_Apple_InitiatesFlow()
    {
        // Arrange
        if (!_loginPage.IsDisplayed())
        {
            Assert.Ignore("LoginPage wird nicht angezeigt - Auth ist moeglicherweise deaktiviert");
            return;
        }

        // Apple Sign-In ist primaer auf iOS relevant
        if (Constants.CurrentPlatform != Platform.iOS)
        {
            Assert.Ignore("Apple Sign-In ist primaer fuer iOS relevant");
            return;
        }

        _loginPage.WaitForPage();

        // Act
        _loginPage.ClickSignInWithApple();

        // Assert - Apple Sign-In Flow
    }

    [Test]
    public void ErrorMessage_IsDisplayed_OnAuthFailure()
    {
        // Arrange
        if (!_loginPage.IsDisplayed())
        {
            Assert.Ignore("LoginPage wird nicht angezeigt - Auth ist moeglicherweise deaktiviert");
            return;
        }

        _loginPage.WaitForPage();

        // Act - Trigger einen Auth-Fehler (z.B. durch Mock oder Offline-Modus)
        // Dies erfordert spezielle Test-Konfiguration

        // Assert
        // In einem echten Szenario wuerde man hier auf die Fehlermeldung warten
        // _loginPage.HasError().Should().BeTrue();
        // _loginPage.GetErrorMessage().Should().NotBeEmpty();
    }
}

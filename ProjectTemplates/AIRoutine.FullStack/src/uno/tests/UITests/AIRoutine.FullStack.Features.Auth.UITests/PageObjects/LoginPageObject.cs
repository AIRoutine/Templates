using AIRoutine.FullStack.Features.Auth.UITests.AutomationIds;
using AIRoutine.FullStack.UITests.Configuration;
using AIRoutine.FullStack.UITests.PageObjects;
using Uno.UITest;

namespace AIRoutine.FullStack.Features.Auth.UITests.PageObjects;

/// <summary>
/// Page Object fuer die LoginPage.
/// </summary>
public class LoginPageObject : BasePage
{
    public LoginPageObject(IApp app) : base(app)
    {
    }

    /// <summary>
    /// Wartet bis die LoginPage geladen ist.
    /// </summary>
    public override void WaitForPage()
    {
        WaitForElement(AuthAutomationIds.LoginPage.Root);
    }

    /// <summary>
    /// Prueft ob die LoginPage sichtbar ist.
    /// </summary>
    public bool IsDisplayed()
    {
        return ElementExists(AuthAutomationIds.LoginPage.Root);
    }

    /// <summary>
    /// Gibt den Welcome-Text zurueck.
    /// </summary>
    public string GetWelcomeText()
    {
        return GetText(AuthAutomationIds.LoginPage.WelcomeText);
    }

    /// <summary>
    /// Gibt den Subtitle-Text zurueck.
    /// </summary>
    public string GetSubtitleText()
    {
        return GetText(AuthAutomationIds.LoginPage.SubtitleText);
    }

    /// <summary>
    /// Klickt auf den Sign-In Button.
    /// </summary>
    public void ClickSignIn()
    {
        Tap(AuthAutomationIds.LoginPage.SignInButton);
    }

    /// <summary>
    /// Klickt auf den Microsoft Sign-In Button.
    /// </summary>
    public void ClickSignInWithMicrosoft()
    {
        Tap(AuthAutomationIds.LoginPage.MicrosoftSignInButton);
    }

    /// <summary>
    /// Klickt auf den Google Sign-In Button.
    /// </summary>
    public void ClickSignInWithGoogle()
    {
        Tap(AuthAutomationIds.LoginPage.GoogleSignInButton);
    }

    /// <summary>
    /// Klickt auf den Apple Sign-In Button.
    /// </summary>
    public void ClickSignInWithApple()
    {
        Tap(AuthAutomationIds.LoginPage.AppleSignInButton);
    }

    /// <summary>
    /// Prueft ob ein Fehler angezeigt wird.
    /// </summary>
    public bool HasError()
    {
        return ElementExists(AuthAutomationIds.LoginPage.ErrorContainer);
    }

    /// <summary>
    /// Gibt die Fehlermeldung zurueck.
    /// </summary>
    public string GetErrorMessage()
    {
        if (!HasError())
        {
            return string.Empty;
        }

        return GetText(AuthAutomationIds.LoginPage.ErrorMessage);
    }

    /// <summary>
    /// Wartet bis der Fehler verschwindet.
    /// </summary>
    public void WaitForErrorToDisappear(TimeSpan? timeout = null)
    {
        WaitForNoElement(AuthAutomationIds.LoginPage.ErrorContainer, timeout ?? Constants.DefaultTimeout);
    }

    /// <summary>
    /// Prueft ob der Busy-Overlay sichtbar ist.
    /// </summary>
    public bool IsBusy()
    {
        return ElementExists(AuthAutomationIds.LoginPage.BusyOverlay);
    }

    /// <summary>
    /// Wartet bis der Busy-Overlay verschwunden ist.
    /// </summary>
    public void WaitForNotBusy(TimeSpan? timeout = null)
    {
        WaitForNoElement(AuthAutomationIds.LoginPage.BusyOverlay, timeout ?? Constants.DefaultTimeout);
    }

    /// <summary>
    /// Prueft ob der Sign-In Button aktiviert ist.
    /// </summary>
    public bool IsSignInButtonEnabled()
    {
        return IsEnabled(AuthAutomationIds.LoginPage.SignInButton);
    }

    /// <summary>
    /// Prueft ob alle Provider-Buttons sichtbar sind.
    /// </summary>
    public bool AreAllProviderButtonsVisible()
    {
        return ElementExists(AuthAutomationIds.LoginPage.MicrosoftSignInButton)
            && ElementExists(AuthAutomationIds.LoginPage.GoogleSignInButton)
            && ElementExists(AuthAutomationIds.LoginPage.AppleSignInButton);
    }

    /// <summary>
    /// Gibt den Title aus der NavigationBar zurueck.
    /// </summary>
    public string GetNavigationTitle()
    {
        return GetText(AuthAutomationIds.LoginPage.NavigationBar);
    }
}

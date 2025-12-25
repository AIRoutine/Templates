namespace AIRoutine.FullStack.Features.Auth.UITests.AutomationIds;

/// <summary>
/// AutomationIds fuer Auth UI-Elemente.
/// Diese IDs muessen in den entsprechenden XAML-Dateien mit
/// AutomationProperties.AutomationId gesetzt werden.
/// </summary>
public static class AuthAutomationIds
{
    /// <summary>
    /// LoginPage-bezogene IDs.
    /// </summary>
    public static class LoginPage
    {
        /// <summary>
        /// Root-Container der LoginPage.
        /// XAML: LoginPage.xaml - Aeusseres Grid Element
        /// </summary>
        public const string Root = "LoginPage.Root";

        /// <summary>
        /// Navigation Header.
        /// XAML: LoginPage.xaml - NavigationBar Element
        /// </summary>
        public const string NavigationBar = "LoginPage.NavigationBar";

        /// <summary>
        /// App-Logo/Icon.
        /// XAML: LoginPage.xaml - Border mit FontIcon
        /// </summary>
        public const string AppLogo = "LoginPage.AppLogo";

        /// <summary>
        /// Welcome-Text.
        /// XAML: LoginPage.xaml - TextBlock "Welcome"
        /// </summary>
        public const string WelcomeText = "LoginPage.WelcomeText";

        /// <summary>
        /// Subtitle-Text.
        /// XAML: LoginPage.xaml - TextBlock "Sign in to continue"
        /// </summary>
        public const string SubtitleText = "LoginPage.SubtitleText";

        /// <summary>
        /// Error-Container.
        /// XAML: LoginPage.xaml - Border mit ErrorContainerBrush
        /// </summary>
        public const string ErrorContainer = "LoginPage.ErrorContainer";

        /// <summary>
        /// Error-Nachricht Text.
        /// XAML: LoginPage.xaml - TextBlock mit ErrorMessage Binding
        /// </summary>
        public const string ErrorMessage = "LoginPage.ErrorMessage";

        /// <summary>
        /// Haupt Sign-In Button.
        /// XAML: LoginPage.xaml - Button "Sign In"
        /// </summary>
        public const string SignInButton = "LoginPage.SignInButton";

        /// <summary>
        /// Divider zwischen Sign-In und Provider-Buttons.
        /// XAML: LoginPage.xaml - Divider Element
        /// </summary>
        public const string Divider = "LoginPage.Divider";

        /// <summary>
        /// "Or continue with" Text.
        /// XAML: LoginPage.xaml - TextBlock vor Provider-Buttons
        /// </summary>
        public const string AlternativeSignInText = "LoginPage.AlternativeSignInText";

        /// <summary>
        /// Microsoft Provider Button.
        /// XAML: LoginPage.xaml - Button mit CommandParameter="Microsoft"
        /// </summary>
        public const string MicrosoftSignInButton = "LoginPage.MicrosoftSignInButton";

        /// <summary>
        /// Google Provider Button.
        /// XAML: LoginPage.xaml - Button mit CommandParameter="Google"
        /// </summary>
        public const string GoogleSignInButton = "LoginPage.GoogleSignInButton";

        /// <summary>
        /// Apple Provider Button.
        /// XAML: LoginPage.xaml - Button mit CommandParameter="Apple"
        /// </summary>
        public const string AppleSignInButton = "LoginPage.AppleSignInButton";

        /// <summary>
        /// Busy Overlay.
        /// XAML: LoginPage.xaml - BusyOverlay Control
        /// </summary>
        public const string BusyOverlay = "LoginPage.BusyOverlay";
    }
}

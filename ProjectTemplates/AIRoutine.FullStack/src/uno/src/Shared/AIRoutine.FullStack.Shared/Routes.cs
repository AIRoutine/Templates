namespace AIRoutine.FullStack.Shared;

/// <summary>
/// Constants for navigation routes and regions.
/// </summary>
public static class Routes
{
    /// <summary>
    /// Region names for Shell layout.
    /// </summary>
    public static class Regions
    {
        /// <summary>Region name for the header area.</summary>
        public const string Header = "HeaderRegion";

        /// <summary>Region name for the footer area.</summary>
        public const string Footer = "FooterRegion";

        /// <summary>Region name for the main content area.</summary>
        public const string Content = "ContentRegion";
    }

    /// <summary>
    /// Page route names for navigation.
    /// </summary>
    public static class Pages
    {
        /// <summary>Route name for the main page.</summary>
        public const string Main = "Main";

        /// <summary>Route name for the second page.</summary>
        public const string Second = "Second";
    }

    /// <summary>
    /// Navigation qualifier for going back.
    /// </summary>
    public const string Back = "-";
}

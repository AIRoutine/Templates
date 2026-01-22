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
        public const string Header = "HeaderRegion";
        public const string Footer = "FooterRegion";
        public const string Content = "ContentRegion";
    }

    /// <summary>
    /// Page route names for navigation.
    /// </summary>
    public static class Pages
    {
        public const string Main = "Main";
        public const string Second = "Second";
    }

    /// <summary>
    /// Navigation qualifier for going back.
    /// </summary>
    public const string Back = "-";
}

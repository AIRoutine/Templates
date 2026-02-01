namespace AIRoutine.FullStack.App.Presentation;

public partial class SecondViewModel(BaseServices baseServices) : PageViewModel(baseServices)
{
    [ObservableProperty]
#pragma warning disable ACS0001 // Template example title
    public partial string Title { get; set; } = "Second Page";
#pragma warning restore ACS0001

    [UnoCommand]
    private async Task GoBackAsync()
    {
        await Mediator.Send(new UnoNavigationRecord(Routes.Back)
        {
            Navigator = Navigator
        });
    }
}

namespace AIRoutine.FullStack.App.Presentation;

public partial class MainViewModel(BaseServices baseServices) : PageViewModel(baseServices)
{
    [ObservableProperty]
    public partial string Title { get; set; } = "AIRoutine.FullStack";

    [ObservableProperty]
    public partial int ClickCount { get; set; }

    [UnoCommand]
    private async Task ClickAsync()
    {
        using (BeginBusy("Processing..."))
        {
            await Task.Delay(500);
            ClickCount++;
        }
    }

    [UnoCommand]
    private async Task GoToSecondPageAsync()
    {
        await Mediator.Send(new UnoNavigationRecord(RoutePages.Second)
        {
            Navigator = Navigator
        });
    }
}

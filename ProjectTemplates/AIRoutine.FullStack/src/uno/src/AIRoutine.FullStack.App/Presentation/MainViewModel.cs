namespace AIRoutine.FullStack.App.Presentation;

public partial class MainViewModel(BaseServices baseServices) : PageViewModel(baseServices)
{
    [ObservableProperty]
    private string _title = "AIRoutine.FullStack";

    [ObservableProperty]
    private int _clickCount;

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
        await Mediator.Send(new UnoNavigationRecord(Routes.Pages.Second)
        {
            Navigator = Navigator
        });
    }
}

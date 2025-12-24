namespace AIRoutine.UnoApp.Presentation;

public partial class MainViewModel(BaseServices baseServices) : PageViewModel(baseServices)
{
    [ObservableProperty]
    private string _title = "AIRoutine.UnoApp";

    [ObservableProperty]
    private int _clickCount;

    [RelayCommand]
    private async Task ClickAsync()
    {
        using (BeginBusy("Processing..."))
        {
            await Task.Delay(500);
            ClickCount++;
        }
    }
}

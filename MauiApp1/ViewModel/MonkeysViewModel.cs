using MauiApp1.Models;
using MauiApp1.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiApp1.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    public Command GetMonkeysCommand { get; }
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finders";
        this.monkeyService = monkeyService;
        GetMonkeysCommand = new Command(async() => await GetMonkeysAsync());
    }

    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            if (monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
                //System.Console.WriteLine(monkey.Location);
            }


        } catch (Exception ex)
        {
            Debug.WriteLine(ex);
            var st = new StackTrace(ex, true);
            var frame = st.GetFrame(0);
            var line = frame.GetFileLineNumber();
            await Shell.Current.DisplayAlert("Error !",
                $"Unable to get monkeys: {ex.Message} {line}","OK");
        }
        finally
        {
            IsBusy = false;
            System.Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Monkeys));
        }
    }
}
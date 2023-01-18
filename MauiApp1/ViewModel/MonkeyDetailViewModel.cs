using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;

namespace MauiApp1.ViewModel;

[QueryProperty("Monkey", "Monkey")]
public partial class MonkeyDetailViewModel : BaseViewModel
{
	IMap map;
	public MonkeyDetailViewModel(IMap map)
	{
		this.map = map;
	}

	[ObservableProperty]
	Monkey monkey;

	[RelayCommand]
	async Task OpenMapAsync()
	{
		try
		{
			await map.OpenAsync(Monkey.Latitude, Monkey.Longitude,
				new MapLaunchOptions
				{
					Name = Monkey.Name,
					NavigationMode = NavigationMode.None
				});
		} catch (Exception ex)
		{
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get closest monkeys: {ex.Message}", "OK");
            return;
        }
	}
}
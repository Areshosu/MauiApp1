using MauiApp1.ViewModel;

namespace MauiApp1;

public partial class MainPage : ContentPage
{

	public MainPage(MonkeysViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}


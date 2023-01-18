using MauiApp1.ViewModel;

namespace MauiApp1.Pages;


public partial class DetailMonkeyPage : ContentPage
{
	public DetailMonkeyPage(MonkeyDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
	}
}
using PcKonfigurator.Client.ViewModels;

namespace PcKonfigurator.Client.Views;

public partial class MainPage : ContentPage
{
    MainPageViewModel viewModel;
    public MainPage(MainPageViewModel vm)
	{
		BindingContext = viewModel = vm;
		InitializeComponent();
	}
}


using PcKonfigurator.Client.ViewModels;

namespace PcKonfigurator.Client.Views;

public partial class AuthenticationPage : ContentPage
{
    AuthenticationPageViewModel viewModel;
    public AuthenticationPage(AuthenticationPageViewModel vm)
	{
		BindingContext = viewModel = vm;
		InitializeComponent();
	}
}


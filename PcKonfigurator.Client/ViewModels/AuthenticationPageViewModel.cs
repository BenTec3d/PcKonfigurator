using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PcKonfigurator.Client.Services;
using PcKonfigurator.Client.Views;
using PcKonfigurator.Shared.DTOs;

namespace PcKonfigurator.Client.ViewModels
{
    public partial class AuthenticationPageViewModel : BaseViewModel
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private CancellationTokenSource cancellationTokenSource = new();

        [ObservableProperty]
        string _username;
        [ObservableProperty]
        string _password;

        public AuthenticationPageViewModel(IAuthenticationRepository authenticationRepository)
        {
            
            _authenticationRepository = authenticationRepository ?? throw new ArgumentNullException(nameof(authenticationRepository));

            Title = "Medium Markt PC Konfigurator";
        }

        [ICommand]
        async Task LoginAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var loginDto = new LoginDto();
                loginDto.Login = Username;
                loginDto.Password = Password;

                var employee = await _authenticationRepository.AuthenticateAsync(loginDto, cancellationTokenSource.Token);

                await Shell.Current.GoToAsync(nameof(MainPage), false,
                    new Dictionary<string, object>
                    {
                        ["Employee"] = employee
                    });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}

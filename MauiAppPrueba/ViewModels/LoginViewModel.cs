
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppPrueba.Services;
using MauiAppPrueba.Views;
using Microsoft.Extensions.Configuration;
using Plugin.Maui.Biometric;


namespace MauiAppPrueba.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;

        public LoginViewModel(IConfiguration configuration)
        {
            _userRepository = new UserService(configuration);
            Email = "admin@appmauiprueba.com";
            Password = "admin12345/";
        }

        [ObservableProperty]
        private string? email;

        [ObservableProperty]
        private string? password;

        [RelayCommand]
        private async Task Login()
        {
            //await Shell.Current.DisplayAlert("Alert", "Login", "OK");
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Email and password are required", "OK");
                return;
            }
            var user = await _userRepository.Login(Email!, Password!);
            if(user == null)
            {
                await Shell.Current.DisplayAlert("Error", "Invalid email or password", "OK");
                return;
            }
            else if(user.Id == 0)
            {
                await Shell.Current.DisplayAlert("Error", "Invalid email or password", "OK");
                return;
            }
            
            var uri = $"{nameof(EmployeesView)}";
            await Shell.Current.GoToAsync(uri);
        }
        [RelayCommand]
        private async void GoCreateAccountView()
        {
            //await DisplayAlert("Alert", "GoCreateAccountView", "OK");
            var uri = $"{nameof(CreateAccountView)}";
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        private async Task BiometricLogin()
        {
            //var biometric = Shell.Current.Services.GetRequiredService<IBiometric>();
            var result = await BiometricAuthenticationService.Default.AuthenticateAsync(new AuthenticationRequest()
            {
                Title = "Utilice la huella para iniciar",
                NegativeText = "Cancelar autenticación",
                AllowPasswordAuth = true
            }, CancellationToken.None);
            if (result.Status == BiometricResponseStatus.Success)
            {
                var uri = $"{nameof(EmployeesView)}";
                await Shell.Current.GoToAsync(uri);
                //await Navigation.PushAsync(new EmployeesView());
            }
            else
            {

                await Shell.Current.DisplayAlert("Biometric", "No se pudo autenticar", "Cancelar");
                return;
            }
        }
    }
}

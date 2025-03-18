using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppPrueba.Services;
using MauiAppPrueba.Views;
using Microsoft.Extensions.Configuration;


namespace MauiAppPrueba.ViewModels
{
    public partial class UsersViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        public UsersViewModel(IConfiguration configuration )
        {
            _userRepository = new UserService(configuration);
        }

        [ObservableProperty]
        private string? email;
        [ObservableProperty]
        private string? password;
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private int id;

        [RelayCommand]
        private async Task Create()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Name))
            {
                await Shell.Current.DisplayAlert("Error", "Email, password and name are required", "OK");
                return;
            }
            var user = new Entities.User
            {
                Email = Email!,
                Password = Password!,
                Name = Name!
            };
            var result = await _userRepository.Create(user);
            if (result == null)
            {
                await Shell.Current.DisplayAlert("Error", "User already exists", "OK");
                return;
            
            }

            await Shell.Current.DisplayAlert("Success", "User has been created successfully!", "OK");

            var uri = $"{nameof(LoginView)}";
            await Shell.Current.Navigation.PopAsync();
        }


    }
}

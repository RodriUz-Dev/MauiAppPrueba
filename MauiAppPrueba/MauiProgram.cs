using MauiAppPrueba.ViewModels;
using MauiAppPrueba.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Biometric;
using System.Reflection;
using Syncfusion.Maui.Toolkit.Hosting;

using MauiAppPrueba.Services;

namespace MauiAppPrueba
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Lato-Bold.ttf", "bold");
                    fonts.AddFont("Lato-Regular.ttf", "regular");
                    fonts.AddFont("Lato-Black.ttf", "black");
                    fonts.AddFont("Lato-Italic.ttf", "italic");
                    fonts.AddFont("FontAwesomeSolid.otf", "SolidFont");
                });

            builder.AddAppSettings();

            // Usar el servicio de autenticación biométrica mediante la inyecion de dependencias
            builder.Services.AddSingleton<IBiometric>(BiometricAuthenticationService.Default);

            // Register views and view models
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<CreateAccountView>();
            builder.Services.AddTransient<EmployeesView>();            
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<UsersViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();
            builder.Services.AddTransient<EditEmployeeViewModel>();
            builder.Services.AddTransient<EmployeeService>();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddSingleton<IEmployeeRepository, EmployeeService>();
            builder.Services.AddSingleton<IUserRepository, UserService>();
           

            Routing.RegisterRoute(nameof(EmployeesView), typeof(EmployeesView));
            Routing.RegisterRoute(nameof(LoginViewModel), typeof(LoginViewModel));
            Routing.RegisterRoute(nameof(CreateAccountView), typeof(CreateAccountView));
            Routing.RegisterRoute(nameof(EditEmployeeView), typeof(EditEmployeeView));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private async static void AddAppSettings(this MauiAppBuilder builder)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("appsettings.json");
            
            var a = Assembly.GetExecutingAssembly();
            using var stream2 = a.GetManifestResourceStream("MauiAppPrueba.appsettings.json");

            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();
            builder.Services.AddSingleton<IConfiguration>(config);
        }
    }
}

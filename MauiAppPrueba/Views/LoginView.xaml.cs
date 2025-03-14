using Microsoft.Maui.Controls;

namespace MauiAppPrueba.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
	}

	private async void GoCreateAccountView(object sender, EventArgs e)
    {
		await DisplayAlert("Alert", "GoCreateAccountView", "OK");
        await Navigation.PushAsync(new CreateAccountView());
    }

    private async void GoEmployeesView(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EmployeesView());
    }
}
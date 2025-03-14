namespace MauiAppPrueba.Views;

public partial class CreateAccountView : ContentPage
{
	public CreateAccountView()
	{
		InitializeComponent();
	}

    private async void GoLoginView(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    
}
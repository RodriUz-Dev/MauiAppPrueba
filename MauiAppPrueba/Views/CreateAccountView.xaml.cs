using MauiAppPrueba.ViewModels;

namespace MauiAppPrueba.Views;

public partial class CreateAccountView : ContentPage
{
	public CreateAccountView(UsersViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }


    //private async void GoLoginView(object sender, EventArgs e)
    //{
    //    await Shell.Current.Navigation.PopAsync();
    //}
}

    
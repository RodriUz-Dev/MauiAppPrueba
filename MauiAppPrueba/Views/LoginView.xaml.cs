using MauiAppPrueba.ViewModels;


namespace MauiAppPrueba.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;            
    }         
    
}
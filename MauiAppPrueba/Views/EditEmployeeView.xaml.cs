using CommunityToolkit.Mvvm.Input;
using MauiAppPrueba.ViewModels;

namespace MauiAppPrueba.Views;

public partial class EditEmployeeView : ContentPage
{
	public EditEmployeeView(EditEmployeeViewModel view)
	{
		InitializeComponent();
        BindingContext = view;
	}

    
    


}
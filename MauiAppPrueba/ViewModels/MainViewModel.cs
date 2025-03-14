
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiAppPrueba.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        private int count;

        [ObservableProperty]
        private string nombre;


        [RelayCommand]
        public void Incrementar()
        {
            Count++;
            Nombre = $"Rodrigo Clicked {Count} times";

        }


    }
}

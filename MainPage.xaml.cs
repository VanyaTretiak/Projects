namespace FinalApp;
using FinalApp.ViewModels;
public partial class MainPage : ContentPage
{

    public MainPage(MainVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    
}
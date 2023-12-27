namespace FinalApp;
using FinalApp.ViewModels;

public partial class FutureTasksPage : ContentPage
{
	public FutureTasksPage(FutureTasksVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}
namespace FinalApp;

using CommunityToolkit.Mvvm.Input;
using FinalApp.ViewModels;
using static System.Net.Mime.MediaTypeNames;

public partial class AddTasksPage : ContentPage
{
	public AddTasksPage(AddTaskVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    
}
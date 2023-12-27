using FinalApp.ViewModels;

namespace FinalApp;

public partial class GeneralTasksPage : ContentPage
{
	//private GeneralTasksVM _viewmodel;
	public GeneralTasksPage(GeneralTasksVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    /*protected override void OnAppearing()
    {
		base.OnAppearing();
		_viewmodel = new GeneralTasksVM();
        _viewmodel.OnAppearing();
    }*/
}
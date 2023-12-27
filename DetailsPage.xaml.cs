namespace FinalApp;
using FinalApp.ViewModels;
public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
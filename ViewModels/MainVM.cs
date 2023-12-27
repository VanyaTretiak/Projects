using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace FinalApp.ViewModels
{
    public partial class MainVM : ObservableObject
    {



        [RelayCommand]
        async Task GoToGeneralTasksPage()
        {
            await Shell.Current.GoToAsync(nameof(GeneralTasksPage));
        }
        [RelayCommand]
        async Task GoToFutureTasksPage()
        {
            await Shell.Current.GoToAsync(nameof(FutureTasksPage));
        }
        [RelayCommand]
        async Task GoToAddTasksPage()
        {
            await Shell.Current.GoToAsync(nameof(AddTasksPage));
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FinalApp.ViewModels;

public partial class FutureTasksVM : ObservableObject
{
    private TodoItemDatabase Database;
    public FutureTasksVM()
    {

        FutureTasks = new ObservableCollection<TaskItem>();
        Database = new TodoItemDatabase();
        Task.Run(async () =>
        {

            var _futureTasks = await Database.GetItemsAsync();
            if (_futureTasks.Any())
            {
                foreach(TaskItem i in _futureTasks)
                {
                    AddItem(i);
                }
            }
            else
                await Database.AddItemAsync("don't forget", "ypu need to wash the dishes", "Future", false);
        });
    }



    [ObservableProperty]
    public ObservableCollection<TaskItem> futureTasks;
    public void AddItem(TaskItem item)
    {
        if (item.Category == "Future")
            FutureTasks.Add(item);
    }


    [RelayCommand]
    async Task GoToBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public void RemoveItem(TaskItem i)
    {
        //FutureTasks
        if (FutureTasks.Contains(i))
        {
            FutureTasks.Remove(i);
            Database.DeleteItemAsync(i);
            //Task.Run(async () => { await Database.DeleteItemAsync(i); });
        }
    }
    [RelayCommand]
    async Task GoToDetailsPage(TaskItem s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Idis={s.Id}");
    }
    [RelayCommand]
    public void Refresh()
    {

        Database = new TodoItemDatabase();
        Task.Run(async () =>
        {
            var _futureTasks = await Database.GetItemsAsync();
            FutureTasks = new ObservableCollection<TaskItem>();
            foreach (TaskItem i in _futureTasks)
            {
                AddItem(i);
            }

        });

    }

}

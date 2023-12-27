using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FinalApp.ViewModels;

public partial class GeneralTasksVM : ObservableObject
{
    private TodoItemDatabase Database;
    public GeneralTasksVM()
    {
        
        GeneralTasks = new ObservableCollection<TaskItem>();
        Database = new TodoItemDatabase();
        Task.Run(async () =>
        {

            var _generalTasks = await Database.GetItemsAsync();
            if (_generalTasks.Any())
            {
                foreach (TaskItem i in _generalTasks)
                {
                    AddItem(i);
                }
            }
            else
                await Database.AddItemAsync("don't forget", "ypu need to wash the dishes", "General", false);
        });
    }
    
    

    [ObservableProperty]
    public ObservableCollection<TaskItem> generalTasks;
    public void AddItem(TaskItem item)
    {
        if(item.Category == "General")
            GeneralTasks.Add(item);
    }


    [RelayCommand]
    async Task GoToBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    public void RemoveItem(TaskItem i)
    {
        //GeneralTasks
        if (GeneralTasks.Contains(i))
        {
            GeneralTasks.Remove(i);
            Database.DeleteItemAsync(i);
            //Task.Run(async () => { await Database.DeleteItemAsync(i); });
        }
    }
    [RelayCommand]
    public void Refresh()
    {
        
        Database = new TodoItemDatabase();
        Task.Run(async () =>
        {
            var _generalTasks = await Database.GetItemsAsync();
            GeneralTasks = new ObservableCollection<TaskItem>();
            foreach (TaskItem i in _generalTasks)
            {
                AddItem(i);
            }
            
        });

    }
    [RelayCommand]
    async Task GoToDetailsPage(TaskItem s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}?Idis={s.Id}");
    }

}

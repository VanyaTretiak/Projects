using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApp.ViewModels;
[QueryProperty("Idis", "Idis")]

public partial class DetailsPageVM : ObservableObject
{
    public DetailsPageVM()
    {
        Database = new TodoItemDatabase();
    }
    private TodoItemDatabase Database;
    [ObservableProperty]
    int idis;
    [ObservableProperty]
    string nameEntry;
    [ObservableProperty]
    string descriptionEntry;
    [ObservableProperty]
    string selectedCategory;
    [ObservableProperty]
    bool doneEntry;


    [RelayCommand]
    async Task LoadItem()
    {
        
        var EditItem = await Database.GetItemAsync(Idis);
        //Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------v");
        //Console.WriteLine(EditItem.Name, EditItem.Desc);
        NameEntry = EditItem.Name;
        DescriptionEntry = EditItem.Desc;
        SelectedCategory = EditItem.Category;
        DoneEntry = EditItem.Done;
    }
    [RelayCommand]
    async Task GoToBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    async Task SaveItem()
    {
        TaskItem item = new TaskItem { 
            Id = Idis,
            Name = NameEntry,
            Desc = DescriptionEntry,
            Category = SelectedCategory,
            Done = DoneEntry
        };
        Database.SaveItemAsync(item);
        NameEntry = string.Empty;
        DescriptionEntry = string.Empty;
        SelectedCategory = string.Empty;
        DoneEntry = false;
        GoToBack();

    }
}

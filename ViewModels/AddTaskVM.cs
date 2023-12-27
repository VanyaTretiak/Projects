using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace FinalApp.ViewModels;

public partial class AddTaskVM : ObservableObject
{
    [ObservableProperty]
    private string selectedCategory;
    [ObservableProperty]
    private string descriptionEntry;
    [ObservableProperty]
    private string nameEntry;
    [ObservableProperty]
    private bool doneEntry;

    private TodoItemDatabase database;
    public AddTaskVM()
    {
        database = new TodoItemDatabase();
        NameEntry = string.Empty;
        DescriptionEntry = string.Empty;
        SelectedCategory = string.Empty;
        DoneEntry = false;
    }

    [RelayCommand]
    async Task GoToBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    [RelayCommand]
    async Task ClearFields() { 
        NameEntry = string.Empty; DescriptionEntry = string.Empty; DoneEntry = false; SelectedCategory = string.Empty;
    }
    [RelayCommand]
    async Task AddTask()
    {
        //Console.WriteLine(SelectedCategory + "   " + DescriptionEntry + " " + NameEntry + " " + DoneEntry);
        //await Task.Delay(10);
        //string p1, p2, p3; bool p4;
        //p1 = NameEntry;
        //bool access = false;
        if (NameEntry != ""
            && NameEntry != "! кхм кхмм"
            && DescriptionEntry != ""
            && DescriptionEntry != "! кхм кхмм"
            && SelectedCategory != ""
            && (SelectedCategory == "General" || SelectedCategory == "Future" ))
        {
            
            await database.AddItemAsync(NameEntry, DescriptionEntry, SelectedCategory, DoneEntry);
            NameEntry = string.Empty;
            DescriptionEntry = string.Empty;
            SelectedCategory = string.Empty;
            DoneEntry = false;
        } else {
        if (NameEntry == "")
            {
                NameEntry = "! кхм кхмм";
            }
        if (DescriptionEntry == "")
            {
                DescriptionEntry = "! кхм кхмм";
            }
        if (SelectedCategory != "General" || SelectedCategory != "Future")
            {
                await App.Current.MainPage.DisplayAlert("Не заповнили", "Заповніть поле категорії", "OK");
            }

        }
        

        
        


        //var taskItem = (TaskItem)BindingContext;
    }
}

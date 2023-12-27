using SQLite;
using System.Collections.ObjectModel;

namespace FinalApp
{
    public class TodoItemDatabase
    {
        static SQLiteAsyncConnection Database;
        /*public static readonly AsyncLazy<TodoItemDatabase> Instance =
            new AsyncLazy<TodoItemDatabase>(async () =>
            {
                var instance = new TodoItemDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<TodoItemDatabase>();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return instance;
            });*/
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DBService.DatabasePath, DBService.Flags);
            var result = await Database.CreateTableAsync<TaskItem>();
        }

        public async Task AddItemAsync(string NameEntry, string DescriptionEntry, string CategoryEntry, bool DoneEntry)
        {
            /*Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("AAAAAAAADDDDDDDDDDDDDDDDDDDDDDDDDDIIIIIIIIIIIIIIIIIIIIITTTTTTTTTTTTTTTEEEEEEEEEEEEEMMMMMMMMMMMMMm");
            */
            await Init();
            var addTask = new TaskItem
            {
                Name = NameEntry,
                Desc = DescriptionEntry,
                Category = CategoryEntry,
                Done = DoneEntry
            };
            await SaveItemAsync(addTask);

        }
        public async Task<List<TaskItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<TaskItem>().ToListAsync();
        }

        public async Task<List<TaskItem>> GetItemsNotDoneAsync()
        {
            await Init();
            return await Database.QueryAsync<TaskItem>("SELECT * FROM [TaskItem] WHERE [Done] = 0");
        }

        public async Task<TaskItem> GetItemAsync(int id)
        {
            await Init();
            return await Database.Table<TaskItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(TaskItem item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }
        /*public async Task EditItemById(int _id)
        {
            await Init();
            Database.QueryAsync("Update * From [TaskItem] Set");
        }*/

        public async Task<int> DeleteItemAsync(TaskItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        public async void DeleteAllItems()
        {
            await Init();
            await Database.DeleteAllAsync<TaskItem>();
        }








        /*public TodoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(DBService.DatabasePath, DBService.Flags);
        }


        public Task<List<TaskItem>> GetItemsAsync()
        {
            return Database.Table<TaskItem>().ToListAsync();
        }

        public Task<List<TaskItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<TaskItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TaskItem> GetItemAsync(int id)
        {
            return Database.Table<TaskItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TaskItem item)
        {
            if (item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TaskItem item)
        {
            return Database.DeleteAsync(item);
        }*/
    }
}
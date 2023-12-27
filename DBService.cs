using SQLite;

namespace FinalApp
{
    public static class DBService
    {
        public const string DatabaseFilename = "ToDoSQLite.db3";
        public const SQLite.SQLiteOpenFlags Flags =
                            SQLite.SQLiteOpenFlags.ReadWrite |
                            SQLite.SQLiteOpenFlags.Create |
                            SQLite.SQLiteOpenFlags.SharedCache;
        
        public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
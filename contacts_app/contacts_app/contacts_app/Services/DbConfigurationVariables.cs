using SQLite;
using System;
using System.IO;

namespace contacts_app.Services
{
    public static class DbConfigurationVariables
    {
        private const string databaseFileName = "db_contacts.db3";

        public const SQLiteOpenFlags OperationsAllowed = SQLiteOpenFlags.Create |
                                                         SQLiteOpenFlags.ReadWrite;

        public static string DatabaseLocation => getDatabasePath();

        private static string getDatabasePath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            return Path.Combine(path, databaseFileName);
        }
    }
}

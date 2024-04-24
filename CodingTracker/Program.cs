using System.Configuration;

namespace CodingTracker
{

    internal class Program
    {
        static string? connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        private static void Main(string[] args)
        {
            DatabaseManager databaseManager = new();
            databaseManager.CreateTable(connectionString);
            Menu.MainMenu();
        }
    }
}
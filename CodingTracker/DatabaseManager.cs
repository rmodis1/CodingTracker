using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class DatabaseManager
    {
        internal void CreateTable(string? connectionString)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCommand = connection.CreateCommand())
                {
                    connection.Open();

                    tableCommand.CommandText =
                   @"CREATE TABLE IF NOT EXISTS coding (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Duration TEXT
                    )";

                    tableCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
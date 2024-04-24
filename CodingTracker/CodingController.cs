using System.Configuration;
using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class CodingController
    {
        string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

        internal void Post(Coding coding)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCommand = connection.CreateCommand())
                {
                    connection.Open();
                    tableCommand.CommandText = $"INSERT INTO coding (date, duration) VALUES ('{coding.Date}', '{coding.Duration}')";
                    tableCommand.ExecuteNonQuery();
                }
            }
        }

        internal List<Coding> Get()
        {
            List<Coding> tableData = new();
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCommand = connection.CreateCommand())
                {
                    connection.Open();
                    tableCommand.CommandText = "SELECT * FROM coding";

                    using (var reader = tableCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("\nNo rows found.\n");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                tableData.Add(
                                new Coding
                                {
                                    Id = reader.GetInt32(0),
                                    Date = reader.GetString(1),
                                    Duration = reader.GetString(2)
                                });
                            }
                        }
                    }
                }
                Console.WriteLine("\n");
            }
            TableVisualization.ShowTable(tableData);
            return tableData;
        }

        internal Coding GetById(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCommand = connection.CreateCommand())
                {
                    connection.Open();

                    tableCommand.CommandText = $"SELECT * FROM coding Where Id = '{id}'";

                    using (var reader = tableCommand.ExecuteReader())
                    {
                        Coding coding = new();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            coding.Id = reader.GetInt32(0);
                            coding.Date = reader.GetString(1);
                            coding.Duration = reader.GetString(2);
                        }
                        Console.WriteLine("\n");
                        return coding;
                    }
                }
            }
        }

        internal void Update(Coding coding)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCommand = connection.CreateCommand())
                {
                    connection.Open();
                    tableCommand.CommandText =
                    $@"UPDATE coding SET 
                          Date = '{coding.Date}', 
                          Duration = '{coding.Duration}' 
                       WHERE 
                          Id = {coding.Id}
                      ";

                    tableCommand.ExecuteNonQuery();
                }
            }

            Console.WriteLine($"\nRecord with Id {coding.Id} was updated.\n");
        }


        internal void Delete(int Id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                using (var tableCommand = connection.CreateCommand())
                {
                    connection.Open();
                    tableCommand.CommandText = $"DELETE FROM coding WHERE Id = '{Id}'";
                    tableCommand.ExecuteNonQuery();

                    Console.WriteLine($"\nRecord with Id {Id} was deleted.\n");
                }
            }
        }
    }
}
using ConsoleTableExt;

namespace CodingTracker
{
    internal class TableVisualization
    {
        internal static void ShowTable<T>(List<T> tableData) where T: class
        {
            Console.WriteLine("\n");
            ConsoleTableBuilder
                .From(tableData)
                .WithTitle("Coding")
                .ExportAndWriteLine();
            Console.WriteLine("\n");
        }
    }
}
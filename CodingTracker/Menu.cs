using System.Globalization;

namespace CodingTracker
{
    internal class Menu
    {
        internal static void MainMenu()
        {
            string invalidCommand = "\nInvalid Command. Please type a number from 0 to 4.\n";

            bool closeApp = false;
            while (closeApp == false)
            {
                Console.WriteLine("\n\nMAIN MENU");
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("\nType 0 to Close Application.");
                Console.WriteLine("Type 1 to View Records");
                Console.WriteLine("Type 2 to Add Records");
                Console.WriteLine("Type 3 to Delete Records");
                Console.WriteLine("Type 4 to Update Records");

                string commandInput = Console.ReadLine();

                while (string.IsNullOrEmpty(commandInput))
                {
                    Console.WriteLine(invalidCommand);
                    commandInput = Console.ReadLine();
                }

                switch (commandInput)
                {
                    case "0":
                        closeApp = true;
                        Environment.Exit(0);
                        break;
                    case "1":
                        CodingController codingController = new();
                        codingController.Get();
                        break;
                    case "2":
                        ProcessInformation.ProcessAdd();
                        break;
                    case "3":
                        ProcessInformation.ProcessDelete();
                        break;
                    case "4":
                        ProcessInformation.ProcessUpdate();
                        break;
                    default:
                        Console.WriteLine(invalidCommand);
                        break;
                }
            }
        }
    }
}
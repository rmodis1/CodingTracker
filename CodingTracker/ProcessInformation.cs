namespace CodingTracker
{
	public static class ProcessInformation
	{
        internal static void ProcessAdd()
        {
            var date = GetInput.GetDateInput();
            var duration = GetInput.GetDurationInput();

            Coding coding = new();

            coding.Date = date;
            coding.Duration = duration;
            CodingController codingController = new();
            codingController.Post(coding);
        }

        internal static void ProcessDelete()
        {
            string backToMenu = "(or enter 0 to retun to the main menu).\n";
            CodingController codingController = new();
            codingController.Get();
            Console.WriteLine("Please add Id of the entry you want to delete " +
                backToMenu);
            string commandInput = Console.ReadLine();
            if (commandInput == "0") Menu.MainMenu();

            int Id;

            bool validEntry = Int32.TryParse(commandInput, out Id)
                && !string.IsNullOrEmpty(commandInput)
                && Int32.Parse(commandInput) >= 0;

            while (!validEntry)
            {
                Console.WriteLine("\nYou have to type a valid Id " + backToMenu);
                commandInput = Console.ReadLine();
                validEntry = Int32.TryParse(commandInput, out Id)
                && !string.IsNullOrEmpty(commandInput)
                && Int32.Parse(commandInput) >= 0;
            }
            if (Id == 0) Menu.MainMenu();

            var coding = codingController.GetById(Id);

            if (coding.Id == 0)
            {
                Console.WriteLine($"\nRecord with Id {Id} does not exist.\n");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadLine();
                ProcessDelete();
            }
            codingController.Delete(Id);
        }

        internal static void ProcessUpdate()
        {
            string backToMenu = "(or enter 0 to retun to the main menu).\n";
            CodingController codingController = new();
            codingController.Get();

            Console.WriteLine("Please add Id of the entry you want to update " + backToMenu);
            string commandInput = Console.ReadLine();

            int Id;

            bool validEntry = Int32.TryParse(commandInput, out Id)
                && !string.IsNullOrEmpty(commandInput)
                && Int32.Parse(commandInput) >= 0;

            while (!validEntry)
            {
                Console.WriteLine("\nYou have to type a valid Id " + backToMenu);
                commandInput = Console.ReadLine();
                validEntry = Int32.TryParse(commandInput, out Id)
                && !string.IsNullOrEmpty(commandInput)
                && Int32.Parse(commandInput) >= 0;
            }
            if (Id == 0) Menu.MainMenu();

            var coding = codingController.GetById(Id);

            while (coding.Id == 0)
            {
                Console.WriteLine($"\nNo record with Id {Id} exists.\n");
                ProcessUpdate();
            }

            bool updating = true;
            while (updating == true)
            {
                Console.WriteLine($"\nType 'd' to change the date\n");
                Console.WriteLine($"\nType 't' to change the amount of time spent on coding\n");
                Console.WriteLine($"\nType 's' to save update\n");
                Console.WriteLine($"\nType '0' to return to the main menu\n");

                var updateInput = Console.ReadLine();

                switch (updateInput)
                {
                    case "d":
                        coding.Date = GetInput.GetDateInput();
                        break;
                    case "t":
                        coding.Duration = GetInput.GetDurationInput();
                        break;
                    case "s":
                        updating = false;
                        break;
                    case "0":
                        Menu.MainMenu();
                        updating = false;
                        break;
                    default:
                        Console.WriteLine($"\nType '0' to return to the main menu\n");
                        break;
                }
            }
            codingController.Update(coding);
            Menu.MainMenu();
        }
    }
}
using System;
using System.Globalization;

namespace CodingTracker
{
	public class GetInput
	{
        internal static string GetDateInput()
        {
            Console.WriteLine("\nPlease insert the date: (Format: mm-dd-yyyy). Type 0 to return to main menu.\n");
            string dateInput = Console.ReadLine();

            if (dateInput == "0") Menu.MainMenu();

            while (!DateTime.TryParseExact(dateInput, "MM-dd-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out _))
            {
                Console.WriteLine("\nNot a valid date. Please insert the date with the format: mm-dd-yyyy.\n");
                dateInput = Console.ReadLine();
            }

            return dateInput;
        }

        internal static string GetDurationInput()
        {
            Console.WriteLine("\nPlease insert the duration of your coding session: (Format: hh:mm). " +
                "Or type 0 to return to the main menu.\n");
            string durationInput = Console.ReadLine();

            if (durationInput == "0") Menu.MainMenu();

            while (!TimeSpan.TryParseExact(durationInput, "h\\:mm", CultureInfo.InvariantCulture, out _))
            {
                Console.WriteLine("\nDuration invalid. Please insert the duration: (Format: hh:mm). " +
                    "Or type 0 to return to main menu.\n");
                durationInput = Console.ReadLine();
                if (durationInput == "0") Menu.MainMenu();
            }
            return durationInput;
        }
    }
}


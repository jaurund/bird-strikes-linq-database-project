using System;
using System.Linq;
using Spectre.Console;
using System.Text.RegularExpressions;

public class UserInput
{
    public static void WelcomeMessage()
    {
        // Console.Clear();
        Console.WriteLine("╔════════════════════════╗");
        Console.WriteLine("║  Welcome to BirdDB!    ║");
        Console.WriteLine("╚════════════════════════╝");
        Console.WriteLine("\n");
        Console.WriteLine("This application allows you to search in all wildlife strike incidents with aircraft between 1990 and 2015.");
        Console.WriteLine("All results will be displayed in a table format for easy reading.");
        Console.WriteLine("\n");
        Console.WriteLine("Suggested keywords for searching can be a specific date or date range, animal species, aircraft type or airline.");
        Console.WriteLine("All date formats supported by the .NET framework are accepted, including 'dd/MM/yyyy', 'MM/dd/yyyy', 'yyyy-MM-dd', etc.");
    }

    public static string GetKeyword()
    {
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        // Validate input: must be at least 3 characters long and contain only letters, numbers, or spaces
        if (input.Length < 3 || !Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$"))
        {
            Console.WriteLine("Invalid input. Please enter at least 3 alphanumeric characters.");
            return GetKeyword(); // Recursive call for re-entry
        }

        return input;
    }
}

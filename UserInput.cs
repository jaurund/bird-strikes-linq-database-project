using System;
using System.Linq;
using System.Text.RegularExpressions;

public class UserInput
{
    public static void WelcomeMessage()
    {
        Console.Clear(); // Optional: clears previous console text
        Console.WriteLine("=======================================");
        Console.WriteLine("  Welcome to the Bird Strike Database  ");
        Console.WriteLine("=======================================");
        Console.WriteLine();
    }

    public static string GetKeyword()
    {
        Console.Write("Enter a keyword to search: ");
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

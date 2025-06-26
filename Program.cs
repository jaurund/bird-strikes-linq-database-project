using System;
using CsvHelper;
using Spectre.Console;
using System.Threading;

// This program reads a CSV file and prints specific rows in tables based on a keyword search.

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Ensure the file exists before reading
        if (File.Exists("database.csv"))
        {
            TextEffects.TypeWriter("\u001b[1;31mReading database.csv...\u001b[0m"); // bold red ANSI escape code
            Thread.Sleep(1000); // Simulate a delay for reading the file          
        }

        else
        {
            Console.WriteLine("Error: database.csv not found.");
            Console.WriteLine("Press esc to exit.");

            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
        UserInput.WelcomeMessage();

        // Main loop for searching, continues until user decides to exit
        while (true)
        {
            var CSVreader = new DatabaseSearcher("database.csv");
            Console.WriteLine("Type below to search:");
            Console.WriteLine("\n");

            string keyword = UserInput.GetKeyword();

            var results = CSVreader.SearchByKeyword(keyword);
            var printer = new TablePrinter();
            printer.PrintTable(results);

            Console.WriteLine("\nPress enter key to search again or ESC to exit.");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                continue;
            }
            else if (key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}

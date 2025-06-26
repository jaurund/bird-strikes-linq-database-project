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
        if (!File.Exists("database.csv"))
        {
            Console.WriteLine("Error: database.csv not found.");
            Console.WriteLine("Press ESC to exit.");
            if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(0);
        }

        TextEffects.TypeWriter("\u001b[1;31mReading database.csv...\u001b[0m"); // bold red ANSI escape code
        Thread.Sleep(1000); // Simulate a delay for reading the file
        UserInput.WelcomeMessage();

        var searchManager = new SearchManager();
        var db = new DatabaseSearcher("database.csv"); // Load once


        // Sully easter egg
        searchManager.OnSearchInput += (input) =>
        {
            if (input.Equals("sully", StringComparison.OrdinalIgnoreCase))
            {
                var sullyRecord = db.SearchSully();
                if (sullyRecord != null)
                {
                    var printer = new TablePrinter();
                    printer.PrintTable(new List<DatabaseRecord> { sullyRecord });
                }
                else
                {
                    Console.WriteLine("Sully record not found.");
                }
            }
        };

        searchManager.OnSearchInput += (input) =>
        {
            if (!input.Equals("sully", StringComparison.OrdinalIgnoreCase))
            {
                var results = db.SearchByKeyword(input);
                var printer = new TablePrinter();
                printer.PrintTable(results);
            }



            while (true)
            {
                Console.WriteLine("Type below to search:");
                string keyword = UserInput.GetKeyword();

                searchManager.ProcessSearch(keyword);

                Console.WriteLine("\nType  to search again or ESC to exit.");
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Enter)
                {
                    // Process the search input
                    searchManager.ProcessSearch(keyword);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }

        };
    }
}


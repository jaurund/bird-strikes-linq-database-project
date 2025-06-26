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

        if (!File.Exists("database.csv"))
        {
            Console.WriteLine("Error: database.csv not found.");
            Console.WriteLine("Press ESC to exit.");
            if (Console.ReadKey().Key == ConsoleKey.Escape) Environment.Exit(0);
        }

        TextEffects.TypeWriter("\u001b[1;31mReading database.csv...\u001b[0m"); // bold red ANSI escape code
        Thread.Sleep(1000); // Simulate a delay for reading the file

        UserInput.WelcomeMessage();

        var db = new DatabaseSearcher("database.csv"); // Load once
        var printer = new TablePrinter();
        var searchManager = new SearchManager();


        // Set up search logic

        while (true)
        {
            Console.WriteLine("\nType below to search:");
            string keyword = UserInput.GetKeyword();

            searchManager.ProcessSearch(keyword);

            Console.WriteLine("\nPress ESC to exit or type another keyword to search again.");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Exiting...");
                break;
            }

        }






    }
}



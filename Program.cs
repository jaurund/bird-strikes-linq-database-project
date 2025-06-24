using System;
using CsvHelper;
using Spectre.Console;

// This program reads a CSV file and prints specific rows in tables based on a keyword search.

class Program
{
    static void Main(string[] args)
    {
        // Ensure the file exists before reading
        if (File.Exists("database.csv"))
        {
            AnsiConsole.MarkupLine("[bold red]Reading database.csv...[/]");
        }
        var CSVreader = new DatabaseSearcher("database.csv");
        var resultRows = CSVreader.SearchByKeyword("gull");


        var printer = new TablePrinter();
        printer.PrintTable(resultRows);
    }
}

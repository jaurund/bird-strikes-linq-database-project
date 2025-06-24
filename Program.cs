using System;
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
        var sully = new SullyFinder();
        List<BirdStrikeRecord> resultRows = sully.FindSully();

        var printer = new TablePrinter();
        printer.PrintTable(resultRows);
    }
}

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
            TextEffects.TypeWriter("\u001b[1;31mReading database.csv...\u001b[0m"); // bold red ANSI escape code

            var CSVreader = new DatabaseSearcher("database.csv");
            var resultRows = CSVreader.SearchByKeyword("102222");

            var printer = new TablePrinter();
            printer.PrintTable(resultRows);
        }
    }
}

using System;
using System.IO;
using System.Linq;
using Spectre.Console;
// This program reads a CSV file and prints specific rows in tables based on a keyword search.

class Program
{
    static void Main(string[] args)
    {
        // Ensure the file exists before reading
        if (File.Exists("database.csv"))
        {
            Console.WriteLine("Reading specific rows from database.csv...");
            ReadSpecificRows();
        }
        else
        {
            Console.WriteLine("File database.csv does not exist.");
        }
    }

    static void ReadSpecificRows()
    {
        var lines = File.ReadAllLines("database.csv");
        var specificRows = lines.Where(line => line.Contains("258272")); // Replace "specificKeyword" with your search term

        foreach (var row in specificRows)
        {
            Console.WriteLine(row);
        }

    }
}


using System;
using System.IO;
using System.Linq;
using Spectre.Console;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
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
        sully.findSully();
    }
}


/*public class SullyFinder
{
    public bool findSully()
    {
        Console.WriteLine("findSully was called");
        AnsiConsole.MarkupLine("Search for Sully:");
        
        if (Console.ReadLine() == "sully")

        {
            var lines = File.ReadAllLines("database.csv");
            var specificRows = lines.Where(line => line.Contains("258272")); // Replace "specificKeyword" with your search term

            foreach (var row in specificRows)
            {
                AnsiConsole.Markup(row);
            }
        }
        else
        {
            AnsiConsole.MarkupLine("Sully not found.");
        }
        return false;
    }
}*/

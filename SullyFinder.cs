using System;
using System.IO;
using System.Linq;
using Spectre.Console;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class SullyFinder
{
    public bool findSully()
    {
        AnsiConsole.MarkupLine("Search for Sully:");

        string input = Console.ReadLine();

        if (input?.ToLower() == "sully") // use the variable
        {
            var lines = File.ReadAllLines("database.csv");
            var specificRows = lines.Where(line => line.Contains("258272"));

            foreach (var row in specificRows)
            {
                AnsiConsole.MarkupLine($"[green]{row}[/]");
            }

            return true;
        }

        AnsiConsole.MarkupLine("[red]No match found or input wasn't 'sully'.[/]");
        return false;
    }
}
using System;
using System.IO;
using System.Linq;
using Spectre.Console;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

public class SullyFinder
{
    public List<BirdStrikeRecord> FindSully()
    {
        string? input = Console.ReadLine(); // Nullable string
        if (string.IsNullOrWhiteSpace(input))
        {
            AnsiConsole.MarkupLine("[red]No input provided.[/]");
            return new List<BirdStrikeRecord>();
        }

        if (input?.ToLower() == "sully") // use the variable
        {
            var lines = File.ReadAllLines("database.csv").Skip(1);
            var matches = lines
                .Where(line => line.Contains("258272"))
                .Select(line => BirdStrikeRecord.FromCsv(line))
                .ToList();

            return matches;
        }

        AnsiConsole.MarkupLine("[red]No match found or input wasn't 'sully'.[/]");
        return new List<BirdStrikeRecord>();
    }
}

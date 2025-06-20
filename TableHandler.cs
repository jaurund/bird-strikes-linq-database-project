using System.Collections.Generic;
using Spectre.Console;

// this file handles tables; the printing of them and what they contain
public class TablePrinter
{
    public void PrintTable(List<BirdStrikeRecord> records)
    {
        if (records == null || records.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No rows to display.[/]");
            return;
        }

        var table = new Table().Border(TableBorder.Rounded).Title("[yellow]Bird Strike Records[/]");

        // Add headers
        table.AddColumn("Record ID");
        table.AddColumn("Year");
        table.AddColumn("Operator");
        table.AddColumn("Aircraft");
        table.AddColumn("Airport");
        table.AddColumn("Species");

        // CHANGED: Using object properties instead of splitting CSV
        foreach (var record in records)
        {
            table.AddRow(
                record.RecordId.ToString(),
                record.Year.ToString(),
                record.Operator,
                record.Aircraft,
                record.Airport,
                record.Species
            );
        }

        AnsiConsole.Write(table);
    }

    private string GetSafe(string[] arr, int index)
    {
        return index < arr.Length ? arr[index] : "[grey]N/A[/]";
    }
}

public class BirdStrikeRecord
{
    public int RecordId { get; set; }
    public int Year { get; set; }
    public string Operator { get; set; }
    public string Aircraft { get; set; }
    public string Airport { get; set; }
    public string Species { get; set; }

    public static BirdStrikeRecord FromCsv(string csvLine)
    {
        var columns = csvLine.Split(',');

        return new BirdStrikeRecord
        {
            RecordId = int.Parse(columns[0]),
            Year = int.Parse(columns[1]),
            Operator = columns[5],
            Aircraft = columns[6],
            Airport = columns[20],
            Species = columns[32]
        };
    }
}


using System;
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

        table.AddColumn("Record ID");
        table.AddColumn("Year");
        table.AddColumn("Month");
        table.AddColumn("Day");
        table.AddColumn("Operator");
        table.AddColumn("Aircraft");
        table.AddColumn("Airport");
        table.AddColumn("Species");

        foreach (var record in records)
        {
            table.AddRow(
                record.RecordId.ToString(),
                record.Year.ToString(),
                record.Month.ToString(),
                record.Day.ToString(),
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
    public int Month { get; set; }
    public int Day { get; set; }
    public DateTime? IncidentDate { get; set; } // new property
    public required string Operator { get; set; }
    public required string Aircraft { get; set; }
    public required string Airport { get; set; }
    public required string Species { get; set; }

    public static BirdStrikeRecord FromCsv(string csvLine)
    {
        var columns = csvLine.Split(',');

        // Parsing year/month/day separately
        bool parsedYear = int.TryParse(columns[1], out int year);
        bool parsedMonth = int.TryParse(columns[2], out int month);
        bool parsedDay = int.TryParse(columns[3], out int day);

        DateTime? date = null;
        if (parsedYear && parsedMonth && parsedDay)
        {
            try
            {
                date = new DateTime(year, month, day);
            }
            catch
            {
                // Handle potential exceptions
                date = null;
            }
        }

        return new BirdStrikeRecord
        {
            RecordId = int.Parse(columns[0]),
            Year = year,
            Month = month,
            Day = day,
            Operator = columns[5],
            Aircraft = columns[6],
            Airport = columns[20],
            Species = columns[32],
        };
    }
}

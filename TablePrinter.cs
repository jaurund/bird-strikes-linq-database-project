using System;
using System.Collections.Generic;
using Spectre.Console;

// this file handles tables; the printing of them and what they contain
public class TablePrinter
{
    public void PrintTable(List<DatabaseRecord> records)
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


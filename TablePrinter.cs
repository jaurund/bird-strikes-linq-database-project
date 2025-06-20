using System.Collections.Generic;
using Spectre.Console;

public class TablePrinter
{
    public void PrintTable(List<string> csvRows)
    {
        if (csvRows == null || csvRows.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No rows to display.[/]");
            return;
        }

        var table = new Table().Border(TableBorder.Rounded).Title("[yellow]Bird Strike Records[/]");

        // Add a few key columns by index in CSV
        table.AddColumn("Record ID");   // 0
        table.AddColumn("Year");        // 1
        table.AddColumn("Operator");    // 5
        table.AddColumn("Aircraft");    // 6
        table.AddColumn("Airport");     // 20
        table.AddColumn("Species");     // 31

        foreach (var line in csvRows)
        {
            var parts = line.Split(',');

            table.AddRow(
                GetSafe(parts, 0), // Record ID
                GetSafe(parts, 1), // Year
                GetSafe(parts, 5), // Operator
                GetSafe(parts, 6), // Aircraft
                GetSafe(parts, 20), // Airport
                GetSafe(parts, 31) // Species
            );
        }

        AnsiConsole.Write(table);
    }

    private string GetSafe(string[] arr, int index)
    {
        return index < arr.Length ? arr[index] : "[grey]N/A[/]";
    }
}

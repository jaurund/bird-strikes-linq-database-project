using System;
using System.Collections.Generic;   // For List<T>
using System.Globalization;         // If you're parsing custom DateTime formats
using System.IO;                    // For File.ReadAllLines
using System.Linq;                  // For LINQ: .Where(), .Select(), .Skip(), etc.
using Spectre.Console;             // Already included for table output (if needed)

public class DatabaseSearcher
{
    private List<DatabaseRecord> allRecords;

    public DatabaseSearcher(string csvPath)
    {
        allRecords = File.ReadAllLines(csvPath)
        .Skip(1) // Skip header row
        .Select(DatabaseRecord.FromCsv)
        .ToList();
    }

    public List<DatabaseRecord> SearchByDateRange(DateTime date)
    {
        return allRecords
            .Where(r => r.IncidentDate.HasValue &&
                        r.IncidentDate.Value.Date == date.Date)
            .ToList();
    }
    public List<DatabaseRecord> SearchByDateRange(DateTime from, DateTime to)
    {
        return allRecords
            .Where(r => r.IncidentDate.HasValue &&
                        r.IncidentDate.Value.Date >= from.Date &&
                        r.IncidentDate.Value.Date <= to.Date)
            .ToList();
    }
    public List<DatabaseRecord> SearchByKeyword(string keyword)
    {
        return allRecords
            .Where(r => r.Operator.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Aircraft.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Airport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Species.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public DatabaseRecord? SearchSully()
    {
        return allRecords.FirstOrDefault(r => r.RecordId == 258272);
    }
}

public class DatabaseRecord
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

    public static DatabaseRecord FromCsv(string csvLine)
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

        return new DatabaseRecord
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

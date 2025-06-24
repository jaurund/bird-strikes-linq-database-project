using System;
using System.Collections.Generic;   // For List<T>
using System.Globalization;         // If you're parsing custom DateTime formats
using System.IO;                    // For File.ReadAllLines
using System.Linq;                  // For LINQ: .Where(), .Select(), .Skip(), etc.
using Spectre.Console;             // Already included for table output (if needed)

public class BirdStrikeSearcher
{
    private List<BirdStrikeRecord> allRecords;

    public BirdStrikeSearcher(string csvPath)
    {
        allRecords = File.ReadAllLines(csvPath)
        .Skip(1) // Skip header row
        .Select(BirdStrikeSearcher.FromCsv)
        .ToList();
    }

    public List<BirdStrikeRecord> SearchByDateRange(DateTime date)
    {
        return allRecords
            .Where(r => r.IncidentDate.HasValue &&
                        r.IncidentDate.Value.Date == date.Date)
            .ToList();
    }
    public List<BirdStrikeRecord> SearchByDateRange(DateTime from, DateTime to)
    {
        return allRecords
            .Where(r => r.IncidentDate.HasValue &&
                        r.IncidentDate.Value.Date >= from.Date &&
                        r.IncidentDate.Value.Date <= to.Date)
            .ToList();
    }
    public List<BirdStrikeRecord> SearchByKeyword(string keyword)
    {
        return allRecords
            .Where(r => r.Operator.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Aircraft.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Airport.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        r.Species.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public BirdStrikeRecord SearchSully()
    {
        return allRecords.FirstOrDefault(r => r.RecordId == 258272);
    }
}
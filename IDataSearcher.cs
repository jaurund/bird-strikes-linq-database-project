using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using DateTime = System.DateTime;

public class SullyFinder // lets user search for the "Sully" bird strike, matches "sully" to indident number "258272" in the database
{
    public List<BirdStrikeRecord> FindSully()
    {
        string? input = Console.ReadLine(); // Nullable string

        if (input?.ToLower() == "sully") // use the variable
        {
            var lines = File.ReadAllLines("database.csv").Skip(1);
            var matches = lines
                .Where(line => line.Contains("258272"))
                .Select(line => BirdStrikeRecord.FromCsv(line))
                .ToList();

            return matches;
        }
        return new List<BirdStrikeRecord>();
    }
}

public class DateParser
{
    private static readonly string[] supportedFormats = new[]
    {
        "yyyy-MM-dd",
        "MM/dd/yyyy",
        "dd/MM/yyyy",
        "yyyy/MM/dd",
        "MM-dd-yyyy",
        "dd-MM-yyyy",
    };

    public bool TryParseFlexibleDate(string input, out DateTime? result)
    {
        result = null;

        if (DateTime.TryParse(input, out DateTime tempResult))
        {
            result = tempResult;
            return true;
        }

        foreach (var format in supportedFormats)
        {
            if (
                DateTime.TryParseExact(
                    input,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces,
                    out DateTime tempResult
                )
            )
            {
                result = tempResult;
                return true;
            }
        }

        return false;
    }
}

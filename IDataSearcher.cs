using System;
using System.IO;
using System.Linq;
using Spectre.Console;
using System.Threading.Tasks;
using DateTime = System.DateTime;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

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

public static class DateParser
{
    public static DateTime? TryParseFlexibleDate(string input)
    {
        if (DateTime.TryParse(input, out DateTime result))
        {
            return result;
        }

        if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out DateTime result))
        {
            return result;
        }

        public static string? input = Console.ReadLine();
        {
            
        }

return null;
    }
}

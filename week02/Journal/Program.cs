using System;

class Program
{
    static void Main(string[] args)
    using System;
}
public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public Entry() { }

    public Entry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    // Convert entry to CSV line with proper escaping
    public string ToCsvString()
    {
        string Escape(string s)
        {
            if (s == null) return "";
            return $"\"{s.Replace("\"", "\"\"")}\"";
        }
        return $"{Escape(Date)},{Escape(Prompt)},{Escape(Response)},{Escape(Mood)}";
    }

    // Create entry from CSV line
    public static Entry FromCsvString(string line)
    {
        // Simple CSV parser assuming proper escaping
        var parts = ParseCsvLine(line);
        if (parts.Length >= 4)
        {
            return new Entry(parts[0], parts[1], parts[2], parts[3]);
        }
        return null;
    }

    // Basic CSV parser to handle quoted fields
    private static string[] ParseCsvLine(string line)
    {
        var result = new System.Collections.Generic.List<string>();
        bool inQuotes = false;
        string current = "";
        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    // Escaped quote
                    current += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (line[i] == ',' && !inQuotes)
            {
                result.Add(current);
                current = "";
            }
            else
            {
                current += line[i];
            }
        }
        result.Add(current);
        return result.ToArray();
    }
}

    


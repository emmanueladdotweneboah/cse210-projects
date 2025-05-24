using System.Collections.Generic;
using System.IO;

public static class ScriptureLoader
{
    public static List<Scripture> LoadScriptures(string filePath)
    {
        var scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            // Fallback hardcoded scriptures
            scriptures.Add(new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
            return scriptures;
        }

        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            // Format: Book|Chapter|StartVerse|EndVerse(optional)|Text
            var parts = line.Split('|');
            if (parts.Length == 5)
            {
                scriptures.Add(new Scripture(new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])), parts[4]));
            }
            else if (parts.Length == 4)
            {
                scriptures.Add(new Scripture(new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2])), parts[3]));
            }
        }

        return scriptures;
    }
}

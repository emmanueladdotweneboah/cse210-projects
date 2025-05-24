using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Load scriptures from file or create manually
        List<Scripture> scriptures = ScriptureLoader.LoadScriptures("scriptures.txt");

        // Select a random scripture
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // hide 3 random visible words
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Goodbye!");
    }
}

// ------------------ Enhancement Notes ------------------
// Exceeded requirements by:
// - Only hiding non-hidden words (stretch challenge).
// - Loading a random scripture from a file with multiple entries.
// - Added a ScriptureLoader utility class.

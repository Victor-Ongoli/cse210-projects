using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For the creativity I added a Hint feature – user can type hint to see the first letter of each hidden word.

class Program
{
    static void Main(string[] args)
    {
        var scriptures = LoadScripturesFromFile("scriptures.txt");
        if (scriptures.Count == 0)
        {
            Reference defRef = new Reference("John", 3, 16);
            string defText = "For God so loved the world that he gave his only begotten Son";
            scriptures.Add(new Scripture(defRef, defText));quit
        }

        Random rand = new Random();
        Scripture current = scriptures[rand.Next(scriptures.Count)];
        int wordsToHide = 3;

        bool quit = false;
        while (!current.IsAllHidden() && !quit)
        {
            Console.Clear();
            Console.WriteLine(current.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide more words.");
            Console.WriteLine("Type 'quit' to exit.");
            Console.WriteLine("Type 'hint' to see the first letter of each hidden word.");

            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
            {
                quit = true;
            }
            else if (input?.ToLower() == "hint")
            {

                Console.Clear();
                Console.WriteLine(current.GetHintDisplayText());
                Console.WriteLine("\n(Hint: first letter of each hidden word is shown)");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }
            else
            {
                current.HideRandomWords(wordsToHide);
            }
        }

        if (current.IsAllHidden())
        {
            Console.Clear();
            Console.WriteLine(current.GetDisplayText());
            Console.WriteLine("\nAll words hidden! Program ending.");
        }
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        var list = new List<Scripture>();
        if (!File.Exists(filename)) return list;
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            string[] parts = line.Split('|');
            if (parts.Length < 5) continue;
            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];
            Reference refObj;
            if (endVerse == 0)
                refObj = new Reference(book, chapter, startVerse);
            else
                refObj = new Reference(book, chapter, startVerse, endVerse);
            list.Add(new Scripture(refObj, text));
        }
        return list;
    }
}
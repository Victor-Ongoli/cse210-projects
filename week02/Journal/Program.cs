
// Creativity on line 21 - 24

using System;

class Program
{
    // Prompt questions
    static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "What am I grateful for today?"
    };

    static void Main(string[] args)
    {
        // For the creativity I added this section for a warm welcome to the daily, it has a date for the day.
        Console.WriteLine();
        Console.WriteLine("Welcome to your Daily Journal!");
        Console.WriteLine();
        Console.WriteLine($"Today is {DateTime.Now.ToString("dddd, MMMM d, yyyy")}");
        Console.WriteLine("Take a moment to reflect on your day... after reflection please do proceed");
        Console.WriteLine();

        // New journal
        Journal journal = new Journal();

        // Menu loop
        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do?: ");
        Console.WriteLine();
    }

    // Random prompt
    static string GetRandomPrompt()
    {
        Random sentence = new Random();
        int index = sentence.Next(_prompts.Count);
        return _prompts[index];
    }

    // Current date
    static string GetCurrentDate()
    {
        DateTime now = DateTime.Now;
        return now.ToString("MM/dd/yyyy");
    }

    // Option 1
    static void WriteNewEntry(Journal journal)
    {
        Console.WriteLine();
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = GetCurrentDate();
        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved!");
    }

    // Option 2
    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine();
        journal.DisplayAll();
    }

    // Option 3
    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    // Option 4
    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            journal.LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
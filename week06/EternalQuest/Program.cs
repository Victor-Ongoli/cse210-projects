using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // CREATIVITY: I added levels based on user's score, like for example Pro, master, champion, etc.
    class Program
    {
        static void Main(string[] args)
        {
            List<Goal> goals = new List<Goal>();
            int score = 0;

            bool running = true;

            while (running)
            {
                DisplayScore(score);
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateGoal(goals); break;
                    case "2": ListGoals(goals); break;
                    case "3": SaveGoals(goals, score); break;
                    case "4": LoadGoals(goals, ref score); break;
                    case "5": RecordEvent(goals, ref score); break;
                    case "6": running = false; break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }

        //Creativity: level and title
        static void DisplayScore(int score)
        {
            int level = score / 00 + 1;
            Console.WriteLine($"You have {score} points. (Level {level} - {GetLevelTitle(level)})");
        }

        static string GetLevelTitle(int level)
        {
            if (level >= 10) return "Ninja";
            if (level >= 7) return "Champion";
            if (level >= 5) return "Master";
            if (level >= 3) return "Pro";
            return "Beginner";
        }

        //Create a new goal
        static void CreateGoal(List<Goal> goals)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        //List goals 
        static void ListGoals(List<Goal> goals)
        {
            Console.WriteLine("The goals are:");
            if (goals.Count == 0)
            {
                Console.WriteLine("  (No goals yet)");
                return;
            }

            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {goals[i].GetDetailsString()}");
            }
        }

        //Record an event
        static void RecordEvent(List<Goal> goals, ref int score)
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            ListGoals(goals);
            Console.Write("Which goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= goals.Count)
            {
                Console.WriteLine("Invalid goal number.");
                return;
            }

            Goal goal = goals[index];

            if (goal.IsComplete())
            {
                Console.WriteLine("That goal is already complete!");
                return;
            }

            int earned = goal.RecordEvent();
            score += earned;

            Console.WriteLine($"Congratulations! You earned {earned} points!");
        }

        //Save goals
        static void SaveGoals(List<Goal> goals, int score)
        {
            Console.Write("what is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(score);
                foreach (Goal goal in goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved to {filename}.");
        }

        //Load goals
        static void LoadGoals(List<Goal> goals, ref int score)
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();
 
            if (!File.Exists(filename))
            {
                Console.WriteLine("No save file found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0) return;

            score = int.Parse(lines[0]);
            goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                int colonIndex = line.IndexOf(':');
                string type = line.Substring(0, colonIndex);
                string[] parts = line.Substring(colonIndex + 1).Split('|');

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(
                            parts[0], parts[1],
                            int.Parse(parts[2]),
                            bool.Parse(parts[3])));
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(
                            parts[0], parts[1],
                            int.Parse(parts[2])));
                        break;
                    case "ChecklistGoal":
                        goals.Add(new ChecklistGoal(
                            parts[0], parts[1],
                            int.Parse(parts[2]),
                            int.Parse(parts[3]),
                            int.Parse(parts[4]),
                            int.Parse(parts[5])));
                        break;
                }
            }

            Console.WriteLine($"Loaded from {filename}.");
        }
    }
}
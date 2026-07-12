using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int x = int.Parse(grade);

        string letter = "";

        if (x >= 90)
        {
            letter = "A";
        }

        else if (x >= 80)
        {
            letter = "B";
        }

        else if (x >= 70)
        {
            letter = "C";
        }

        else if (x < 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (x >= 70)
        {
            Console.WriteLine("Congratulations! You passed your class!");
        }

        else
        {
            Console.WriteLine("Unfortunately you didn't achieve the pass mark. We encourage you to try again");
        }

    }
}
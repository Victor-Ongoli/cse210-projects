using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        // Console.Write("What is the magic number? ");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);

        // int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guessNumber = int.Parse(Console.ReadLine());

        while (guessNumber != magicNumber)
        {
            if (guessNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.WriteLine("Higher");
            }

            Console.Write("What is your guess? ");
            guessNumber = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("You guessed it right!");
    }
}
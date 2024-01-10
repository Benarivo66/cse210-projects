using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);
        
        int guess = 0;

        while (magicNumber != guess)
        {
            Console.WriteLine("What is your guess? ");
            string guessString = Console.ReadLine();
            guess = int.Parse(guessString);

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else if (magicNumber == guess)
            {
                Console.WriteLine("Congratulations");
            }
        }

    }
}
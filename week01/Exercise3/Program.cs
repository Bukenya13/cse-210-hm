using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        
        while (playAgain == "yes")
        {
            
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            
            int guess = 0;
            int numberOfGuesses = 0;
            
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                numberOfGuesses++;
                
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                }
            }
            
            
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        }
        
        Console.WriteLine("Thanks for playing!");
    }
}
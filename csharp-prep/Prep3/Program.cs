using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNum;
        int numGuess;
        int guessCount;
        string playAgain;

        Random randomGenerator = new Random();
        magicNum = randomGenerator.Next(1, 100);
        
        do
        {
            guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                numGuess = int.Parse(Console.ReadLine());
                guessCount++;
                if (numGuess < magicNum)
                {
                    Console.WriteLine("Higher");
                }
                else if (numGuess > magicNum)
                {
                    Console.WriteLine("Lower");
                }
            }
            while (numGuess != magicNum);
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} guesses");
            Console.WriteLine("");
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        } while (playAgain == "yes");
    }
}
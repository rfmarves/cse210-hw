using System;

class Program
{
    static void Main(string[] args)
    {
        void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
        string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }
        int PromptUserNumber()
        {
            Console.Write("Please enter your name: ");
            return int.Parse(Console.ReadLine());
        }
        int SquareNumber(int number)
        {
            return number * number;
        }
        void DisplayResults(string name, int number)
        {
            Console.WriteLine($"{name}, the square of your number is {number}");
        }

        string name;
        int number;
        int squaredNumber;
        DisplayWelcome();
        name = PromptUserName();
        number = PromptUserNumber();
        squaredNumber = SquareNumber(number);
        DisplayResults(name, squaredNumber);

        Console.WriteLine("Hello Prep5 World!");
    }
}
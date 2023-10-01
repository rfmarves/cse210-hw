using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your journal!");
        bool notExit = true;
        string choice = "";
        string fileName = "";
        Journal thisJournal = new Journal();

        do
        {
        Console.WriteLine();
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write - Random prompt");
        Console.WriteLine("2. Write - Custom prompt");
        Console.WriteLine("3. Display");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Save");
        Console.WriteLine("6. Quit");
        choice = Console.ReadLine();
        if (choice == "1")
        {
           Prompt newPrompt = new Prompt(); // starts a prompt object to get a random prompt
           thisJournal.AddEntry(newPrompt.RandomPrompt());  // Gets a random prompt from the prompts class
        }
        else if (choice == "2")
        {
            Console.Write("Enter your custom prompt: ");
            string promptText = Console.ReadLine();
            thisJournal.AddEntry(promptText);
        }
        else if (choice == "3")
        {
            thisJournal.DisplayOnScreen();
        }
        else if (choice == "4")
        {
            Console.WriteLine("Please enter the file name to open.");
            Console.Write("Filename: ");
            fileName = Console.ReadLine();
            thisJournal.ReadFromFile(fileName);
        }
        else if (choice == "5")
        {
            Console.WriteLine("Please enter the file name to save.");
            Console.Write("Filename: ");
            fileName = Console.ReadLine();
            thisJournal.SaveToFile(fileName);
        }
        else if (choice == "6")
        {
            notExit = false;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Invalid choice, please enter a valid option.");
            Console.WriteLine();
        }
        } while (notExit);
        Console.WriteLine();
        Console.WriteLine("Thank you for journaling with us.");
    }
}
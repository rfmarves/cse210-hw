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
        if (choice == "1") // Write new prompt based on random prompt
        {
           Prompt newPrompt = new Prompt(); // starts a prompt object to get a random prompt
           thisJournal.AddEntry(newPrompt.RandomPrompt());  // Gets a random prompt from the prompts class
        }
        else if (choice == "2") // Write a prompt based on custom prompt option. Added to show creativity
        {
            Console.Write("Enter your custom prompt: "); // Added this as additional option to show creativity.
            string promptText = Console.ReadLine();      // This gets a custom prompt from the user.
            thisJournal.AddEntry(promptText);
        }
        else if (choice == "3")  // Display journal option
        {
            thisJournal.DisplayOnScreen();  // Display the Journal on screen using the DisplayOnScreen method
        }
        else if (choice == "4")  // Load from file option
        {
            Console.WriteLine("Please enter the file name to open.");  
            Console.Write("Filename: ");
            fileName = Console.ReadLine();
            thisJournal.ReadFromFile(fileName);
        }
        else if (choice == "5") // Save to file option
        {
            Console.WriteLine("Please enter the file name to save.");
            Console.Write("Filename: ");
            fileName = Console.ReadLine();
            thisJournal.SaveToFile(fileName);
        }
        else if (choice == "6") // quit option
        {
            notExit = false;
        }
        else // in case of invalid input, this option gets triggered
        {
            Console.WriteLine();
            Console.WriteLine("Invalid choice, please enter a valid option.");
            Console.WriteLine();
        }
        } while (notExit);
        Console.WriteLine();
        Console.WriteLine("Thank you for journaling with us."); // goodbye message on quitting.
    }
}
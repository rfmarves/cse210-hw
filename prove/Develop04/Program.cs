using System;

class Program
{
    static void Main(string[] args)
    {
        const string _breathingActivityName = "Breathing Activity";
        const string _breathingActivityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        string SelectMenuItem()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4" };
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listening activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");
                choice = Console.ReadLine();
                // if (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
                // {
                //     Console.WriteLine("\nPlease enter a valid option.\n");
                // }
            }
            return choice;
        }

        string selectedItem = "";
        while (selectedItem != "4")
        {
            selectedItem = SelectMenuItem();
            if (selectedItem == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.RunActivity();
            } else if (selectedItem == "2")
            {
                Console.WriteLine("option 2");
            } else if (selectedItem == "3")
            {
                Console.WriteLine("option 3");
            }
        }

        Console.WriteLine("\nWell done!!\n");
    }
}
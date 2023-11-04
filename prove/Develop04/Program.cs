using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        static string SelectMenuItem()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4" };
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        string selectedItem = "";
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();
        while (selectedItem != "4")
        {
            selectedItem = SelectMenuItem();
            if (selectedItem == "1")
            {
                breathingActivity.RunActivity();
            } else if (selectedItem == "2")
            {
                reflectingActivity.RunActivity();
            } else if (selectedItem == "3")
            {
                listingActivity.RunActivity();
            }
        }

        Console.WriteLine("\nWell done!!\n");
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        EventList events = new EventList();

        events.LoadFromFile("events.txt");

        // Menu function
        static int  Menu()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4" };
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");
                Console.WriteLine(" 1. Display short description of all events (listing)");
                Console.WriteLine(" 2. Display standard details for all events");
                Console.WriteLine(" 3. Display full details for all");
                Console.WriteLine(" 4. Quit");
                Console.Write("Write your choice: ");
                choice = Console.ReadLine();
                Console.WriteLine();
            }
            return int.Parse(choice);
        }
        
        static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Runs main program options
        int selectedItem = 0;
        while (selectedItem != 4)
        {
            selectedItem = Menu();
            if (selectedItem == 1)
            {
                Console.Clear();
                events.DisplayEventsShort();
                PressAnyKey();
            }
            else if(selectedItem == 2) 
            {
                Console.Clear();
                events.DisplayEventsStandard();
                PressAnyKey();
            }
            else if(selectedItem==3)
            {
                Console.Clear();
                events.DisplayEventsDetailed();
                PressAnyKey();
            }
        }

        Console.WriteLine("Thank you for using this program");
    }
}
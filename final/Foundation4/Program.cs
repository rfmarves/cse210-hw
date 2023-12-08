using System;

class Program
{
    static void Main(string[] args)
    {
        const string defaultFileName = "activities.txt";
        ActivityList activities = new ActivityList();

        activities.LoadFromFile(defaultFileName);

        // Menu function
        static int  Menu()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4", "5", "6"};
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Please select an option:");
                Console.WriteLine(" 1. Display activities");
                Console.WriteLine(" 2. Add activity");
                Console.WriteLine(" 3. Remove activity");
                Console.WriteLine(" 4. Import Activities");
                Console.WriteLine(" 5. Export Activities");
                Console.WriteLine(" 6. Quit");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
                Console.WriteLine();
            }
            return int.Parse(choice);
        }

        // submenu for activities
        static int ActivitySelection()
        {
            string choice = "";
            List<string> options = new List<string> {"1", "2", "3","4"};
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine("Please select the activity type to create");
                Console.WriteLine(" 1. Running");
                Console.WriteLine(" 2. Stationary Bicycle");
                Console.WriteLine(" 3. Swimming");
                Console.WriteLine(" 4. Cancel/Back to main menu");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();
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
        while(selectedItem != 6)
        {
            selectedItem = Menu();
            if(selectedItem == 1)
            // display activities
            {
                activities.DisplayActivities();
                PressAnyKey();
            }
            else if(selectedItem == 2)
            // add activity
            {
                int activityChoice = ActivitySelection();
                if(activityChoice == 1)
                // add running activity
                {
                    Running activityToAdd = new Running();
                    activityToAdd.CreateFromConsole();
                    activities.Add(activityToAdd);
                }
                else if(activityChoice == 2)
                // add stationary bicycle activity
                {
                    StationaryBicycle activityToAdd = new StationaryBicycle();
                    activityToAdd.CreateFromConsole();
                    activities.Add(activityToAdd);
                }
                else if(activityChoice == 3)
                // add swimming activity
                {
                    Swimming activityToAdd = new Swimming();
                    activityToAdd.CreateFromConsole();
                    activities.Add(activityToAdd);
                }
            }
            else if(selectedItem == 3)
            // Remove activity
            {
                Console.WriteLine("Here are the current activities: ");
                activities.DisplayActivities();
                Console.Write("\nWrite number of activity to remove: ");
                string toRemove = Console.ReadLine();
                int index = 0;
                if(int.TryParse(toRemove, out index) && index > 0 && index < activities.Count())
                {
                    activities.Remove(index-1);
                } else
                {
                    Console.WriteLine("Invalid input.");
                }
                PressAnyKey();
            }
            else if(selectedItem == 4)
            // Import activities from file
            {
                Console.Write("\nPlease enter filename for activity list to import: ");
                string fileName = Console.ReadLine();
                activities.LoadFromFile(fileName);
                Console.WriteLine("Activities imported.");
                PressAnyKey();
            }
            else if(selectedItem == 5)
            // export activities to file
            {
                Console.Write("\nPlease enter filename to save exported activity list: ");
                string fileName = Console.ReadLine();
                activities.SaveToFile(fileName);
                Console.WriteLine("File saved.");
                PressAnyKey();
            }
        }

        activities.SaveToFile(defaultFileName);
        Console.WriteLine("Thank you for using this program.");
    }
}
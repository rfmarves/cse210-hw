using System;

class Program
{
    static void Main(string[] args)
    {
        const string _defaultFileName = "goals.txt";
        GoalsList _goals = new GoalsList();
        string selectedItem = "";
        
        // Helper functions
        string DisplayMenu()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4", "5", "6", "7"};
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine( "┌──────────────────────────┐");
                Console.WriteLine( "│ Menu Options:            │");
                Console.WriteLine( "│   1. Create New Goal     │");
                Console.WriteLine( "│   2. List Goals          │");
                Console.WriteLine( "│   3. Export Goals        │");
                Console.WriteLine( "│   4. Import Goals        │");
                Console.WriteLine( "│   5. Record Event        │");
                Console.WriteLine( "│   6. Delete Goal         │");
                Console.WriteLine( "│   7. Quit                │");
                Console.WriteLine( "└──────────────────────────┘");
                Console.WriteLine($" You have {_goals.GetScore()} points.");
                Console.WriteLine();
                Console.Write(" Select a choice from the menu: ");
                choice = Console.ReadLine();
            }
            return choice;
        }

        string SelectGoalType()
        {
            string choice = "";
            List<string> options = new List<string> { "1", "2", "3", "4",};
            while (!options.Contains(choice, StringComparer.OrdinalIgnoreCase))
            {
                Console.Clear();
                Console.WriteLine( "┌──────────────────────────┐");
                Console.WriteLine( "│ The types of goals are:  │");
                Console.WriteLine( "│   1. Simple Goal         │");
                Console.WriteLine( "│   2. Eternal Goal        │");
                Console.WriteLine( "│   3. Checklist Goal      │");
                Console.WriteLine( "│                          │");
                Console.WriteLine( "│   4. Cancel              │");
                Console.WriteLine( "└──────────────────────────┘");
                Console.WriteLine($" You have {_goals.GetScore()} points.");
                Console.WriteLine();
                Console.Write(" Select a choice from the menu: ");
                choice = Console.ReadLine();
            }
            return choice;
        }
        // end of helper functions

        if(File.Exists(_defaultFileName))
        {
            _goals.ImportFromFile(_defaultFileName);
        }
        while (selectedItem != "7")
        {
            selectedItem = DisplayMenu();
            if (selectedItem == "1")
            {
                // create a goal option
                string goalType = SelectGoalType();
                if(goalType == "1")
                {
                    _goals.Add(new SimpleGoal());
                } else if (goalType == "2")
                {
                    _goals.Add(new EternalGoal());
                } else if (goalType == "3")
                {
                    _goals.Add(new ChecklistGoal());
                }
            } else if (selectedItem == "2")
            {
                //List goals
                _goals.ListGoals();
                Console.WriteLine("\nPress a key to continue.");
                Console.ReadKey();
            } else if (selectedItem == "3")
            {
                //export goals
                Console.Write("What is the filename for the goal file? ");
                string fileName = Console.ReadLine();
                _goals.ExportToFile(fileName);
            } else if (selectedItem == "4")
            {
                // import goals
                Console.Write("What is the filename for the goal file? ");
                string fileName = Console.ReadLine();
                _goals.ImportFromFile(fileName);
            } else if (selectedItem == "5")
            {
                // record event
                _goals.RecordEvent();
            } else if (selectedItem == "6")
            {
                // delete a gola
                _goals.DeleteGoal();
            }
        }
        _goals.ExportToFile(_defaultFileName);
    }
}
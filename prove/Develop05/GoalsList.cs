class GoalsList
{
    protected List<Goal> _goalList;
    protected int _score = 0;

    public GoalsList()
    {
        _goalList = new List<Goal>();
    }
    protected int ReadGoalNumber()
    {
        int number;
        if(!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Please enter a valid goal number: ");
            number = ReadGoalNumber();
        } else if(number > _goalList.Count() || number <= 0)
        {
            Console.Write("Please enter a valid goal number: ");
            number = ReadGoalNumber();
        }
        return number;
    }
    public void Add(Goal newGoal)
    {
        _goalList.Add(newGoal);
    }

    public void ListGoals(Boolean listAll = true)
    {
        int goalCount = _goalList.Count();
        Console.Clear();
        if(goalCount == 0)
        {
            Console.WriteLine("\nNo goals set.");
        } else
        {
            string stringFormat = "{0,1:#}";
            if(goalCount > 9 ) {stringFormat = "{0,2:##}";}
            if(goalCount > 99) {stringFormat = "{0,3:###}";}

            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goalList.Count; i++)
            {
                if(listAll || !_goalList[i].IsDone())
                {
                    Console.Write($"{string.Format(stringFormat,i+1)}. ");
                    _goalList[i].PrintGoal();
                    Console.WriteLine();
                }
            }
        }
    }

    public void RecordEvent()
    {
        ListGoals(false);
        Console.Write("Which goal did you accomplish? ");
        Goal accomplishedGoal = _goalList[ReadGoalNumber() - 1];
        if(!accomplishedGoal.IsDone())
        {
            int wonPoints = accomplishedGoal.RecordEvent(); 
            Console.WriteLine($"Congratulations! You have earned {wonPoints} points!");
            _score += wonPoints;
            Console.WriteLine($"You now have {_score} points.");
        } else {
            Console.WriteLine("That goal was already accomplished.");
        }
        Console.WriteLine("Press a key to continue.");
        Console.ReadKey();
    }

    public void DeleteGoal()
    {
        ListGoals();
        Console.Write("Which goal do you want to delete? ");
        int goalNumber = ReadGoalNumber();
        Console.WriteLine($"This will delete goal {goalNumber}. {_goalList[goalNumber - 1].GetName()}");
        Console.Write("Are you sure want to delete? (y/n) ");
        string response = Console.ReadLine().ToLower();
        if (response == "y")
        {
            _goalList.RemoveAt(goalNumber-1);
            Console.WriteLine("Goal deleted.");
        } else
        {
            Console.WriteLine("Operation cancelled.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public int GetScore()
    {
        return _score;
    }

    public void ExportToFile(string fileName)
    {
        using StreamWriter outputFile = new StreamWriter(fileName);
        outputFile.WriteLine(GetScore()); // first line is the current score
        foreach (Goal g in _goalList)
        {
            outputFile.WriteLine(g.Serialize()); // writes each line based on the methods in the Goal class and children
        }
    }

    public void ImportFromFile(string fileName)
    {
        _goalList.Clear(); // starts with fresh list of goals
        string serializedGoal;
        using StreamReader sr = new StreamReader(fileName);
        _score = int.Parse(sr.ReadLine());
        while (sr.Peek() >= 0)
        {
            serializedGoal = sr.ReadLine();
            string[] parts = serializedGoal.Split(":");
            if (parts[0]=="SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(parts[1]);
                _goalList.Add(g);
            } else if (parts[0]=="EternalGoal") 
            {
                EternalGoal g = new EternalGoal(parts[1]);
                _goalList.Add(g);
            } else if (parts[0]=="ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(parts[1]);
                _goalList.Add(g);
            } else
            {
                Goal g = new Goal(parts[1]);
                _goalList.Add(g);
            }
        }
    }
}
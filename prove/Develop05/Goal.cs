class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalPoints;
    protected int _eventCount;
    protected Boolean _goalDone;

    public Goal()
    {
        Console.Write("What is the name of your goal? ");
        _goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _goalPoints = ReadInteger();
        _goalDone = false;
        _eventCount = 0;
    }
    public Goal(string goalString)
    // deserializes the goal
    {
        string[] parts = goalString.Split("|");
        _goalName = parts[0];
        _goalDescription = parts[1];
        _goalPoints = int.Parse(parts[2]);
        _eventCount = int.Parse(parts[3]);
        _goalDone = Boolean.Parse(parts[4]);
    }
    
    public Goal(string goalName, string goalDescription, int points)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _goalPoints = points;
    }

    protected static int ReadInteger()
    {
        int number;
        if(!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Please enter a valid number: ");
            number = ReadInteger();
        }
        return number;
    }

    public virtual string Serialize()
    {
        return $"Goal:{_goalName}|{_goalDescription}|{_goalPoints}|{_eventCount}|{_goalDone}";
    }

    public virtual int RecordEvent()
    {
        _eventCount += 1;
        return _goalPoints;
    }

    public virtual void PrintGoal()
    {
        string statusString = "";
        string countDetail = "";
        if(_goalDone) {statusString = "x";}
        else {statusString = " ";}
        if(_eventCount > 0 && !_goalDone) {countDetail = $" - done {_eventCount} times.";}
        Console.Write($"[{statusString}] {_goalName} ({_goalDescription}){countDetail}");
    }

    public virtual Boolean IsDone()
    {
        return _goalDone;
    }

    public virtual string GetName()
    {
        return _goalName;
    }
}
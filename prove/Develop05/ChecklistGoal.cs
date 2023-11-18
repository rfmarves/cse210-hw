class ChecklistGoal : Goal
{
    int _bonusPoints;
    int _targetEvents;

    public ChecklistGoal() : base()
    {
        Console.Write("How many times does thi goal need to be accomplished for a bonus? ");
        _targetEvents = ReadInteger();
        Console.Write("What is the bonus for accomplishing it that many times? ");
        _bonusPoints = ReadInteger();
    }

    public ChecklistGoal(string goalString) : base(goalString)
    // deserializes the goal
    {
        string[] parts = goalString.Split("|");
        _targetEvents = int.Parse(parts[5]);
        _bonusPoints = int.Parse(parts[6]);
    }

    public ChecklistGoal(string goalName, string goalDescription, int points, int targetEvents, int bonusPoints) : base(goalName, goalDescription, points)
    {
        _targetEvents = targetEvents;
        _bonusPoints = bonusPoints;
    }

   public override string Serialize()
    {
        return $"ChecklistGoal:{_goalName}|{_goalDescription}|{_goalPoints}|{_eventCount}|{_goalDone}|{_targetEvents}|{_bonusPoints}";
    }

    public override int RecordEvent()
    {
        if(!_goalDone)
        {
            _eventCount += 1;
            if(_eventCount >= _targetEvents)
            {
                _goalDone = true;
                return _goalPoints + _bonusPoints;
            } else
            {
                return _goalPoints;
            }
        } else 
        {
            return 0;
        }
    }

    public override void PrintGoal()
    {
        string statusString = " ";
        if(_goalDone) {statusString = "x";}
        Console.Write($"[{statusString}] {_goalName} ({_goalDescription}) - Currently completed: {_eventCount}/{_targetEvents}");
    }
    public override bool IsDone()
    {
        return base.IsDone();
    }
    public override string GetName()
    {
        return base.GetName();
    }
}
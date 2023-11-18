class EternalGoal : Goal
{
    public EternalGoal() : base() {}

    public EternalGoal(string goalString) : base(goalString) {}
    // deserializes the goal
    
    public EternalGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points) {}

   public override string Serialize()
    {
        return $"EternalGoal:{_goalName}|{_goalDescription}|{_goalPoints}|{_eventCount}|{_goalDone}";
    }

    public override int RecordEvent()
    {
        _eventCount += 1;
        return _goalPoints;
    }

    public override void PrintGoal()
    {
        base.PrintGoal();
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
class SimpleGoal : Goal
{
    
    public SimpleGoal() : base() {}

    public SimpleGoal(string goalString) : base(goalString) {}
    // deserializes the goal

    public SimpleGoal(string goalName, string goalDescription, int points) : base(goalName, goalDescription, points)
    {

    }

    public override string Serialize()
    {
        return $"SimpleGoal:{_goalName}|{_goalDescription}|{_goalPoints}|{_eventCount}|{_goalDone}";
    }



    public override int RecordEvent()
    {
        if(!_goalDone)
        {
            _goalDone = true;
            _eventCount += 1;
            return _goalPoints;
        } else {
            return 0;
        }
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
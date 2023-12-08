class Swimming : Activity
{
    private int _numberOfLaps = 0;

    public Swimming() : base("Swimming") {}

    public Swimming(string serializedData) : base("Swimming", serializedData)
    {
        string[] parameters = serializedData.Split("|");
        _numberOfLaps = int.Parse(parameters[2]);
    }

    public Swimming(DateOnly date, float duration, int numberOfLaps) : base(date, duration)
    {
        _numberOfLaps = numberOfLaps;
    }

    public override string SerializeActivity()
    {
        return $"{base.SerializeActivity()}|{_numberOfLaps}";
    }


    public override float GetDistance()
    {
        return _numberOfLaps*50/1000;
    }

    public override float GetSpeed()
    {
        return GetDistance()/GetDuration() * 60;
    }

    public override float GetPace()
    {
        return GetDuration()/GetDistance();
    }

    public override string GetSummary()
    {
        return base.GetSummary();
    }

    public override void CreateFromConsole()
    {
        base.CreateFromConsole();
        _numberOfLaps = IntEntry("Please enter number of laps: ");
    }
}
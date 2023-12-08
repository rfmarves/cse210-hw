class Running : Activity
{
    private float _distance = 0;

    public Running() : base("Running") {}

    public Running(string serializedData) : base("Running", serializedData)
    {
        string[] parameters = serializedData.Split("|");
        _distance = float.Parse(parameters[2]);
    }

    public Running(DateOnly date, float duration, float distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override string SerializeActivity()
    {
        return $"{base.SerializeActivity()}|{_distance}";
    }

    public override float GetDistance()
    {
        return _distance;
    }

    public override float GetSpeed()
    {
        return _distance/GetDuration()*60;
    }

    public override float GetPace()
    {
        return GetDuration()/_distance;
    }

    public override string GetSummary()
    {
        return base.GetSummary();
    }

    public override void CreateFromConsole()
    {
        base.CreateFromConsole();
        _distance = FloatEntry("Please enter distance ran in km: ");
    }
}
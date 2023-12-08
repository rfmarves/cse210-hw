class StationaryBicycle : Activity
{
    private float _speed = 0;

    public StationaryBicycle() : base("Stationary Bicycle") {}

    public StationaryBicycle(string serializedData) : base("Stationary Bicycle",serializedData)
    {
        string[] parameters = serializedData.Split("|");
        _speed = float.Parse(parameters[2]);
    }

    public StationaryBicycle(DateOnly date, float duration, float speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override string SerializeActivity()
    {
        return $"{base.SerializeActivity()}|{_speed}";
    }


    public override float GetDistance()
    {
        return _speed*GetDuration()/60;
    }

    public override float GetSpeed()
    {
        return _speed;
    }

    public override float GetPace()
    {
        return 60/_speed;
    }

    public override string GetSummary()
    {
        return base.GetSummary();
    }

    public override void CreateFromConsole()
    {
        base.CreateFromConsole();
        _speed = FloatEntry("Please enter the speed in kph: ");
    }
}
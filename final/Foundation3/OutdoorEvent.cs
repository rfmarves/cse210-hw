class OutdoorEvent : Event
{
    private string _weather;

    public OutdoorEvent(string title, string description, DateOnly date, TimeOnly time, string address, string weather) : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public OutdoorEvent(string serializedParameters) : base(serializedParameters)
    {
        string[] parameters = serializedParameters.Split("|");
        _weather = parameters[5];
    }

    public void SetWeather(string weather)
    {
        _weather = weather;
    }

    public override void DisplayFull()
    {
        Console.WriteLine(StandardText());
        Console.WriteLine( "Event Type : Outdoor Event");
        Console.WriteLine($"Weather    : {_weather}");
    }

    public override void DisplayShort()
    {
        Console.WriteLine($"Outdoor Event: {ShortText()}");
    }
}
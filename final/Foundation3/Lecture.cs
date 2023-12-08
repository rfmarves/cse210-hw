class Lecture : Event
{
    private string _speaker;
    private int _capacity;
    private const string _eventType = "Lecture";

    public Lecture(string title, string description, DateOnly date, TimeOnly time, string address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public Lecture(string serializedParameters) : base(serializedParameters)
    {
        string[] parameters = serializedParameters.Split("|");
        _speaker = parameters[5];
        _capacity = int.Parse(parameters[6]);
    }

    public void SetSpeaker(string speaker)
    {
        _speaker = speaker;
    }

    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }

    public override void DisplayFull()
    {
        Console.WriteLine(StandardText());
        Console.WriteLine($"Event Type : {_eventType}");
        Console.WriteLine($"Speaker    : {_speaker}");
        Console.WriteLine($"Capacity   : {_capacity}");
    }

    public override void DisplayShort()
    {
        Console.WriteLine($"{_eventType}: {ShortText()}");
    }
}
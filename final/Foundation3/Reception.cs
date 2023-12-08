class Reception : Event
{
    private string _confirmationDetails;
    private const string _eventType = "Reception";

    public Reception(string title, string description, DateOnly date, TimeOnly time, string address, string confirmationDetails) : base(title, description, date, time, address)
    {
        _confirmationDetails = confirmationDetails;
    }

    public Reception(string serializedParameters) : base(serializedParameters)
    {
        string[] parameters = serializedParameters.Split("|");
        _confirmationDetails = parameters[5];
    }

    public void SetConfirmationDetails(string confirmationDetails)
    {
        _confirmationDetails = confirmationDetails;
    }

    public override void DisplayFull()
    {
        Console.WriteLine(StandardText());
        Console.WriteLine($"Event Type : {_eventType}");
        Console.WriteLine($"RSVP here  : {_confirmationDetails}");
    }

    public override void DisplayShort()
    {
        Console.WriteLine($"{_eventType}: {ShortText()}");
    }
}
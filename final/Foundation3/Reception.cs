class Reception : Event
{
    private string _confirmationDetails;

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
        Console.WriteLine( "Event Type : Reception");
        Console.WriteLine($"RSVP here  : {_confirmationDetails}");
    }

    public override void DisplayShort()
    {
        Console.WriteLine($"Reception: {ShortText()}");
    }
}
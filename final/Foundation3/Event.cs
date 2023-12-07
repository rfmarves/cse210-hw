using System.Dynamic;

class Event
{
    private string _title;
    private string _description;
    private DateOnly _date;
    private TimeOnly _time;
    private string _address;

    public Event(string title, string description, DateOnly date, TimeOnly time, string address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public Event(string serializedParameters)
    {
        string[] parameters = serializedParameters.Split("|");
        _title = parameters[0];
        _description = parameters[1];
        _date = DateOnly.ParseExact(parameters[2], "yyyy-MM-dd", null);
        _time = TimeOnly.ParseExact(parameters[3], "HH:mm:ss", null);
        _address = parameters[4];
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public void SetDate(DateOnly date)
    {
        _date = date;
    }

    public void SetTime(TimeOnly time)
    {
        _time = time;
    }

    public void SetAddress(string address)
    {
        _address = address;
    }

    public string StandardText()
    {
        return $"Event title: {_title}\nDescription: {_description}\nDate       : {_date}\nTime       : {_time}\nAddress    : {_address}";
    }

    public void DisplayStandard()
    {
        Console.WriteLine(StandardText());
    }

    public string ShortText()
    {
        return $"{_title}, {_date}";
    }

    public virtual void DisplayFull()
    {
        Console.WriteLine(StandardText());
        Console.WriteLine("Event Type: Generic Event");
    }

    public virtual void DisplayShort()
    {
        Console.WriteLine($"Generic Event: {ShortText()}");
    }

}
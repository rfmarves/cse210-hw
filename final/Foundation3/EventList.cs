class EventList
{
    private List<Event> _events = new List<Event>();

    public EventList() {}

    public void LoadFromFile(string fileName)
    {
        string line;
        using StreamReader sr = new StreamReader(fileName);
        while (sr.Peek() >= 0)
        {
            line = sr.ReadLine();
            string[] parts = line.Split(":", 2);
            if (parts[0]=="Lecture") {_events.Add(new Lecture(parts[1]));}
            else if (parts[0]=="Reception") {_events.Add(new Reception(parts[1]));}
            else if (parts[0]=="Outdoor Event") {_events.Add(new OutdoorEvent(parts[1]));}
            else  {_events.Add(new Event(parts[1]));}
        }
    }

    public void DisplayEventsShort()
    {
        Console.WriteLine("Here is the event listing:\n");
        foreach (Event e in _events)
        {
            Console.Write("- ");
            e.DisplayShort();
        }
    }

    public void DisplayEventsStandard()
    {
        Console.WriteLine("Here are the standard details for all events:\n");
        foreach (Event e in _events)
        {
            e.DisplayStandard();
            Console.WriteLine();
        }
    }

    public void DisplayEventsDetailed()
    {
        Console.WriteLine("Here are the full event details for all events:\n");
        foreach (Event e in _events)
        {
            e.DisplayFull();
            Console.WriteLine("\n================================================================\n");
        }
    }

}
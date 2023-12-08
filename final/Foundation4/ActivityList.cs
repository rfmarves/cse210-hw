class ActivityList
{
    private List<Activity> _activities = new List<Activity>();

    public ActivityList() {}

    public void LoadFromFile(string fileName)
    {
        string line;
        using StreamReader sr = new StreamReader(fileName);
        while (sr.Peek() >= 0)
        {
            line = sr.ReadLine();
            string[] parts = line.Split(":", 2);
            if (parts[0]=="Running") {_activities.Add(new Running(parts[1]));}
            else if (parts[0]=="Stationary Bicycle") {_activities.Add(new StationaryBicycle(parts[1]));}
            else if (parts[0]=="Swimming") {_activities.Add(new Swimming(parts[1]));}
            else  {_activities.Add(new Activity("Activity",parts[1]));}
        }
    }
    public void SaveToFile(string fileName)
    {
        using StreamWriter outputFile = new StreamWriter(fileName);
        foreach (Activity a in _activities)
        {
            outputFile.WriteLine(a.SerializeActivity()); // writes each line based on the methods in the Activities class and children
        }
    }

    public void DisplayActivities()
    {
        for (int i = 0; i < _activities.Count; i++)
        {
            Console.WriteLine($"{(i+1).ToString().PadLeft(3)}. {_activities[i].GetSummary()}");
        }
        // foreach (Activity a in _activities)
        // {
        //     Console.WriteLine(a.GetSummary());
        // }
    }

    public void Add(Activity activity)
    {
        _activities.Add(activity);
    }

    public void Remove(int index)
    {
        _activities.RemoveAt(index);
        Console.WriteLine($"Activity {index + 1} removed.");
    }

    public int Count()
    {
        return _activities.Count();
    }
}
using System.Runtime.InteropServices;

class Activity
{
    private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
    private float _duration = 0;

    private string _activityName = "Activity";

    public Activity(DateOnly date, float duration)
    {
        _date = date;
        _duration = duration;
    }

    public Activity(string activityName, string serializedData)
    {
        _activityName = activityName;
        string[] parameters = serializedData.Split("|");
        _date = DateOnly.ParseExact(parameters[0], "yyyy-MM-dd", null);
        _duration = float.Parse(parameters[1]);
    }

    public Activity(string activityName)
    {
        _activityName = activityName;
    }
    public Activity() {}

    public virtual string SerializeActivity()
    {
        return $"{_activityName}:{_date.ToString("yyyy-MM-dd")}|{_duration}";
    }

    public virtual void SetActivity(string activity)
    {
        _activityName = activity;
    }
    public virtual void SetDate(DateOnly date)
    {
        _date = date;
    }

    public virtual void SetDuration(float duration)
    {
        _duration = duration;
    }

    public DateOnly GetDate()
    {
        return _date;
    }

    public float GetDuration()
    {
        return _duration;
    }
    
    public virtual float GetDistance()
    {
        return 0;
    }

    public virtual float GetSpeed()
    {
        return 0;
    }

    public virtual float GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        string dateFormat = "dd MMM yyyy";
        string numberFormat = "0.0";
        return $"{_date.ToString(dateFormat)} {_activityName} ({_duration} min): Distance {GetDistance().ToString(numberFormat)} km, Speed: {GetSpeed().ToString(numberFormat)} kph, Pace: {GetPace().ToString(numberFormat)} min per km";
    }

    public virtual void CreateFromConsole()
    {
        Console.WriteLine("Activity date entry: ");
        int? year = IntNullEntry("Please enter the 4-digit year or press [Enter] to select today");
        if(year == null)
        {
            _date = DateOnly.FromDateTime(DateTime.Now);
        } else
        {
            int month = IntEntry("Please enter the month number: ");
            int day = IntEntry("Please enter day number: ");
            _date = new DateOnly(year ?? 0, month, day);
        }
        _duration = FloatEntry("Please enter activity duration: ");
    }

    public static int IntEntry(string message)
    {
        int result;
        Console.Write(message);
        string consoleInput = Console.ReadLine();
        if(!int.TryParse(consoleInput, out result))
        {
            Console.WriteLine("Invalid input, please enter an integer.");
            return IntEntry(message);
        }
        return result;
    }
    public static int? IntNullEntry(string message)
    {
        int result;
        Console.Write(message);
        string consoleInput = Console.ReadLine();
        if(consoleInput == "")
        {
            return null;
        }
        else if(!int.TryParse(consoleInput, out result))
        {
            Console.WriteLine("Invalid input, please enter an integer.");
            return IntEntry(message);
        }
        return result;
    }


    public static float FloatEntry(string message)
    {
        float outputInt;
        Console.Write(message);
        string consoleInput = Console.ReadLine();
        if(!float.TryParse(consoleInput, out outputInt))
        {
            Console.WriteLine("Invalid input, please enter a number.");
            outputInt = IntEntry(message);
        }
        return outputInt;
    }
}
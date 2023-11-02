class Activity
{
    protected string _activityName = "";
    protected string _activityDescription = "";
    protected int _duration = 30;
    protected string _durationPrompt = "How long, in seconds, would you like for your session? ";
    protected string _endMessage = "Well done!!\n";

    public Activity()
    {
        // nothing to return
    }

    public void SetName(string name)
    {
        _activityName = name;
    }

    public void SetDescription(string description)
    {
        _activityDescription = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        _duration = GetInt(_durationPrompt);
    }

    public string GetEndingMessage()
    {
        return _endMessage;
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        SpinnerPause();
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_activityName}.");
        SpinnerPause();
    }

    public void SpinnerPause(int spinnerDuration = 5)
    {
        List<string> charSequence = new List<string> { "-", "\\", "|", "/"};
        int runs = 0;
        int charPause = 500;
        while (runs*charPause < spinnerDuration*1000)
        {
            Console.Write(charSequence[runs % 4]);
            Thread.Sleep(charPause);
            runs ++;
            Console.Write("\b \b");
        }
    }

    public void CountdownTimer(int countdownDuration = 6)
    {
        while (countdownDuration > 0)
        {
            Console.Write(countdownDuration);
            Thread.Sleep(1000);
            countdownDuration --;
            Console.Write("\b \b");
        }
    }
    public static int GetInt(string message)
    {
        bool inputSuccess = false;
        int returnValue = 0;
        while (!inputSuccess)
        {
            Console.WriteLine();
            Console.Write(message);
            inputSuccess = int.TryParse(Console.ReadLine(), out returnValue);
            if (!inputSuccess) {Console.WriteLine("Please enter valid number.");}
        }
        return returnValue;
    }
}
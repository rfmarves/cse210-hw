class BreathingActivity : Activity
{
    int _breatheInTime = 4;
    int _breathOutTime = 6;
    public BreathingActivity() : base()
    {
        _activityName = "Breathing Activity";
        _activityDescription = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        DisplayStartingMessage();
        Console.Write("Do you want to customize breathing times? (Y/N) ");
        string response = Console.ReadLine();
        if (response[0].ToString().ToLower() == "y")
        {
            _breatheInTime = GetInt("Enter your breathe in time in seconds: ");
            _breathOutTime = GetInt("Enter your breathe out time in seconds: ");
        }
    }

    public void RunActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        SpinnerPause();
        Console.WriteLine();
        int lapsedTime = 0;
        while (lapsedTime < _duration)
        {
            Console.Write("Breathe in...");
            CountdownTimer(_breatheInTime);
            Console.Write("\nNow breathe out...");
            CountdownTimer(_breathOutTime);
            lapsedTime += _breathOutTime + _breatheInTime;
            Console.WriteLine("\n");
        }
        _duration = lapsedTime;
        DisplayEndingMessage();
    }

}
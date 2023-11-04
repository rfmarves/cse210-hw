using System.Threading.Channels;

class Activity
{
    protected string _activityName = "";
    protected string _activityDescription = "";
    protected int _duration = 30;
    protected string _durationPrompt = "How long, in seconds, would you like for your session? ";
    protected string _endMessage = "Well done!!\n";

    public Activity()
    {
       // Nothing needed here
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        _duration = GetInt(_durationPrompt);
    }

    public void DisplayEndingMessage(int spinnerDuration = 5)
    {
        Console.WriteLine("Well done!!");
        SpinnerPause(spinnerDuration);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_activityName}.");
        SpinnerPause(spinnerDuration);
    }

    public static void SpinnerPause(int spinnerDuration = 5)
    {
        List<string> charSequence = new List<string> { "-", "\\", "|", "/"};
        int charPause = 500;
        for ( int runs = 0; runs*charPause < spinnerDuration*1000; runs++)
        {
            Console.Write(charSequence[runs % 4]);
            Thread.Sleep(charPause);
            Console.Write("\b \b");
        }
    }

    public static void CountdownTimer(int countdownDuration = 6)
    {
        for (int i = countdownDuration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if        (i < 10) {Console.Write("\b \b");}
            else if  (i < 100) {Console.Write("\b\b  \b\b");}
            else if (i < 1000) {Console.Write("\b\b\b   \b\b\b");}
        }
    }

    public static void BarTimer(int type = 0, int countdownDuration = 10, int bars = 20)
    {
        // Type 0 is grow an shrink 
        // Type 1 is grow
        // Type 2 is shrink
        char barChar = Convert.ToChar("░");
        int denominator = bars;
        if (type == 0) {denominator=bars*2-1;}
        int sleepPause = (int)Math.Round(countdownDuration * 1000 / ((double)denominator));
        for (int i = 0; i < bars; i++)
        {            
            Console.Write(barChar);
            if (type == 0 || type == 1) {Thread.Sleep(sleepPause); }
        }
        for (int i = 0; i < bars; i++)
        {
            Console.Write("\b \b");
            if (type == 0 || type == 2) {Thread.Sleep(sleepPause);}
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

    public static void GetReady(int spinnerDuration = 5)
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        SpinnerPause(spinnerDuration);
        Console.WriteLine();
    }
}
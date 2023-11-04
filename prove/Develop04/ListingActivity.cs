using System.Diagnostics;

class ListingActivity : Activity
{
    private List<string> _promptList = new List<string> {
        "Who are people that you appreciate?", 
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?" };
    
    private List<string> _responseList = new List<string> {};

    public ListingActivity() : base()
    {
        _activityName = "Listing Activity";
        _activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    private string GetPrompt()
    {
        var rnd = new Random();
        return _promptList[rnd.Next(_promptList.Count)];
    }

    public void RunActivity()
    {
        DisplayStartingMessage();
        GetReady();
        Console.WriteLine( "List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetPrompt()} ---");
        Console.Write("You may begin in: ");
        CountdownTimer(10);
        Console.WriteLine();
        Stopwatch counter = new Stopwatch();
        counter.Start();
        while (counter.ElapsedMilliseconds < _duration*1000)
        {
            Console.Write("> ");
            _responseList.Add(Console.ReadLine());
        }
        counter.Stop();
        Console.WriteLine($"You listed {_responseList.Count()} items!\n");
        _duration = (int)(counter.ElapsedMilliseconds/1000);
        DisplayEndingMessage();
        // var dummy = Console.ReadLine();
    }
}
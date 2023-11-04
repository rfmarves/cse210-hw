class ReflectingActivity : Activity
{
    private List<string> _promptList = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless." };
    private List<string> _questionList = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"  };
    // private string _promptResponse;
    private int _currentQuestion = 0;
    private int _currentPrompt = 0;
    private int _questionDuration = 10;

    public ReflectingActivity() : base()
    {
        _activityName = "Reflecting Activity";
        _activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        RandomizeList(ref _promptList);
        RandomizeList(ref _questionList);
    }

    public void RunActivity()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine( "Consider the following prompt:\n");
        Console.WriteLine($" --- {GetNextPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press [Enter] to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        CountdownTimer(5);
        Console.WriteLine();
        Console.Write($"Current duration per question is {_questionDuration} seconds. Do you want to change it? (Y/N)");
        string response = Console.ReadLine().ToLower();
        if (response == "y" || response == "yes") {ChangeQuestionDuration();}
        DisplayQuestions(_questionDuration);
        DisplayEndingMessage(6);
    }

    private void ChangeQuestionDuration()
    {
        _questionDuration = GetInt("Enter time to display each question, in seconds: ");
    }
    private void DisplayQuestions(int questionDuration = 6)
    {
    int questionQuantity =   (int)Math.Round((double)_duration / (double)questionDuration);
        if (_questionList.Count - _currentQuestion < questionQuantity)
        {
            RandomizeList(ref _questionList);
            _currentQuestion = 0;
        }
        for (int i = 0; i < questionQuantity; i++)
        {
            Console.Write($"> {GetNextQuestion()} ");
            BarTimer(2, questionDuration);
            Console.WriteLine();
        }
        _duration = questionQuantity * questionDuration;
    }

    private static void RandomizeList(ref List<string> toMakeRandom)
    {
        List<string> tempList = new List<string> {};
        tempList = toMakeRandom;
        var rnd = new Random();
        toMakeRandom = tempList.OrderBy(_ => rnd.Next()).ToList();
    }
    
    private static string GetNext(ref List<string> listItems, ref int currentItem)
    {
        string output = listItems[currentItem];
        currentItem += 1;
        if (currentItem >= listItems.Count)
        {
            RandomizeList(ref listItems);
            currentItem = 0;
        }
        return output;
    }
    private string GetNextPrompt()
    {
        return GetNext(ref _promptList, ref _currentPrompt);
    }

    private string GetNextQuestion()
    {
        return GetNext(ref _questionList, ref _currentQuestion);
    }
}
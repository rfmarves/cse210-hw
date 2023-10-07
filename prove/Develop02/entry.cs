// Class: Entry
// Attributes:
// * _date : string
// * _prompt : string
// * _content : string

// Behaviors:
// * DisplayOnScreen() : void
// * StringForFile() : string

using System.Security.Cryptography.X509Certificates;

public class Entry
{
    public string _date = "";
    public string _prompt = "";
    public string _content = "";
    public Entry()
    {
    }

    public void DisplayOnScreen()
    // Displays one journal entry to the console
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine($"{_content}");
        Console.WriteLine();
    }

    public string StringForFile()
    // Returns string formatted to be added to a saved file
    {
        return String.Format($"{_date}|{_prompt}|{_content}");
    }

}

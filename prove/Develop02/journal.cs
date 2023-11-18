// Class: Journal
// Attributes:
// * _entries : list<Entry>

// Behaviors:
// * DisplayOnScreen() : void
// * AddEntry() : void
// * SaveToFile(fileName): void
// * ReadFromFile(fileName): void

using System.IO; 

public class Journal
{
    public List<Entry> _entries = new List<Entry>(); // property where all journal entries are stored
    public Journal()
    {
    }

    public void DisplayOnScreen()
    // Displays to console all journal entries
    {
        Console.WriteLine();
        if (_entries.Count == 0) // Gets triggered if no journal entries exist
        {
            Console.WriteLine("There are no journal entries to display");
        }
        else
        {
            Console.WriteLine("These are your journal entries:");
            foreach (Entry e in _entries) //loops through all entries in the journal
            {
                e.DisplayOnScreen(); //uses the method in the Entry class to display the entries
            }
        } 
    }

    public void AddEntry(string promptText)
    // Adds a new journal entry, prompting the user for inputs
    {
        Entry newEntry = new Entry();
        DateTime theCurrentTime = DateTime.Now; // Gets the current date and time for the entry
        newEntry._date = theCurrentTime.ToShortDateString(); // Records the date in a standard format as text
        newEntry._prompt = promptText;
        Console.WriteLine($"Prompt: {newEntry._prompt}"); // Displays the writing prompt
        Console.WriteLine("Type your entry:");
        newEntry._content = Console.ReadLine(); // collects the journal entry
        _entries.Add(newEntry); // Adds the journal entry to the journal object
    }

    public void SaveToFile(string fileName)
    // Saves journal entries to a text file with given file name
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine(e.StringForFile()); // writes each line based on the method in the Entry class
            }
        }
    }

    public void ReadFromFile(string fileName)
    // Loads journal entries from text file with given file name
    {
        _entries.Clear(); //starts with a fresh list of entries
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            Entry newEntry = new Entry();
            string[] parts = line.Split("|");
            newEntry._date = parts[0];
            newEntry._prompt = parts[1];
            newEntry._content = parts[2];
            _entries.Add(newEntry); // Adds the journal entry to the journal object
        }
    }
}

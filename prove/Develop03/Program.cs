using System;

class Program
{
    static void Main(string[] args)
    {
        string book1 = "John";
        int chapter1 = 3;
        int firstVerse1 = 16;
        string scriptureText1 = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        
        string book2 = "Proverbs";
        int chapter2 = 3;
        int firstVerse2 = 5;
        int lastVerse2 = 6;
        List<string> scriptureText2 = new List<string>() {"Trust in the Lord with all thine heart; and lean not unto thine own understanding.", 
            "In all thy ways acknowledge him, and he shall direct thy paths."};
        
        // Load all references into reference list
        List<Reference> referenceList = new List<Reference>();
        referenceList.Add(new Reference(book1,chapter1,firstVerse1,scriptureText1));
        referenceList.Add(new Reference(book2, chapter2, firstVerse2,lastVerse2,scriptureText2));

        // pick a random reference
        var rnd = new Random();
        Scripture selectedScripture = new Scripture(referenceList[rnd.Next(referenceList.Count)]);

        // Display scripture loop
        string choice = "";
        Boolean allHidden = false;
        do {
            // display scripture
            Console.Clear();
            selectedScripture.GetRenderedText();
            // user input
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            choice = Console.ReadLine();
            // quit or continue
            if(choice == "quit")
            {
                break;
            }
            else
            {
                allHidden = selectedScripture.IsCompletelyHidden();
                if(allHidden){break;}
            }
            // hide words
            selectedScripture.HideWords();
        } while(true);
        //quit
    }
}
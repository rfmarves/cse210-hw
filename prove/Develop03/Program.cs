using System;

class Program
{
    static void Main(string[] args)
    {
        // Variable declarations
        string fileName = "scriptures.txt";
        List<Reference> referenceList = new List<Reference>();
        var rnd = new Random();
        string choice;
        Boolean allHidden;
        
         // Load file with scriptures
        string[] scriptureList = System.IO.File.ReadAllLines(fileName);

        // convert to list of reference objects
        foreach(string line in scriptureList)
        {
            List<string> parts = line.Split("|").ToList();
            if(parts.Count > 5)
            {
                string paramBook = parts[0];
                int paramChapter = int.Parse(parts[1]);
                int paramVerse1 = int.Parse(parts[2]);
                int paramVerse2 = int.Parse(parts[3]);
                parts.RemoveAt(3);
                parts.RemoveAt(2);
                parts.RemoveAt(1);
                parts.RemoveAt(0);
                referenceList.Add(new Reference(paramBook, paramChapter, paramVerse1, paramVerse2, parts));
            }
            else
            {
                referenceList.Add(new Reference(parts[0],int.Parse(parts[1]),int.Parse(parts[2]),parts[4]));
            }
        }
        
        // Start of picking a scripture loop
        do {
        // pick a random reference
        Scripture selectedScripture = new Scripture(referenceList[rnd.Next(referenceList.Count)]);
        selectedScripture.UnhideAll();

            // Display scripture loop
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
            } while(true); // end of display scripture loop

            // continues or quit scripture loop
            Console.WriteLine();
            Console.WriteLine("Press enter to get another scripture or type 'quit' to finish:");
            choice = Console.ReadLine();
            if(choice == "quit") 
            {
                break;
            }
        } while(true); //end of picking a scripture loop
        // end of program
    }
}
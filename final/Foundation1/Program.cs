using System;

class Program
{
    
    
    static void Main(string[] args)
    {
        List<Video> _videos = new List<Video>();
        string  _fileName = "youtubeData.txt";

        string _videoLine;
        string _tempAuthor;
        string _tempTitle;
        int _tempLength;
        string _tempCommenter;
        string _tempText;
        using StreamReader sr = new StreamReader(_fileName);
        while (sr.Peek() >= 0)
        {
            _videoLine = sr.ReadLine();
            string[] parts = _videoLine.Split("|");
            _tempTitle = parts[0];
            _tempAuthor = parts[1];
            _tempLength = int.Parse(parts[2]);
            Video v = new Video(_tempTitle, _tempAuthor, _tempLength);
            for (int i = 3; i < parts.Count(); i = i + 2)
            {
                _tempCommenter = parts[i];
                _tempText = parts[i+1];
                v.AddComment(_tempCommenter, _tempText);
            }
            _videos.Add(v);
        }

        static void ItemBreak()
        {
            Console.WriteLine();
            Console.WriteLine("==================================================================");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine();
        }

        foreach (Video v in _videos)
        {
            v.DisplayVideoCard();
            ItemBreak();
        }
    }
}
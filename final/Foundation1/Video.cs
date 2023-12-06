class Video
{
    private string _title = "";
    private string _author = "";
    private int _length = 0;
    private List<Comment> _comments = new List<Comment>();

    public Video() {}

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetNumberOfComments()
    {
        return _comments.Count();
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public void AddComment(string commenter, string text)
    {
        _comments.Add(new Comment(commenter, text));
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

    public void SetAuthor(string author)
    {
        _author = author;
    }

    public void SetLength(int length)
    {
        _length = length;
    }
    
    public void DisplayVideoCard()
    {
        Console.WriteLine( "\n*********** Video Information ***********");
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"by {_author}, Length: {_length} seconds.\n");
        Console.WriteLine($"There are {GetNumberOfComments()} comments in video.")
        Console.WriteLine("========= Comments ==========");
        foreach (Comment c in _comments)
        {
            c.Display();
        }
    }
}
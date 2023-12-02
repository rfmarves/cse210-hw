class Comment
{
    private string _commenterName;
    private string _comment;

    public Comment(string commenter, string text)
    {
        _commenterName = commenter;
        _comment = text;
    }

    public string Serilize()
    {
        return $"{_commenterName}|{_comment}";
    }

    public string Formatted()
    {
        return $"@{_commenterName}: {_comment}\n";
    }

    public void Display() 
    {
        Console.WriteLine(Formatted());
    }
} 
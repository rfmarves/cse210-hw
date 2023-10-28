class WritingAssignment : Assignment
{
    private string _title;
    
    public string GetWritingInformation() {
        return $"{_title} by {_studentName}";
    }

    public WritingAssignment(string name,string topic, string title) : base(name, topic) {
        _title = title;
    }
}
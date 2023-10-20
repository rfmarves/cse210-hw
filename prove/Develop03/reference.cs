// class Reference {
// 	- _book : string
// 	- _chapter : int
// 	- _firstVerse : int
// 	- _lastVerse : int
// 	- _scriptureText : list~string~
// 	+ GetReferenceText() string 
// 	+ GetScriptureText() string
// 	+ SetReference(string) void SKIPPED
// 	+ SetText(string) void SKIPPED
// 	+ Reference(book, chapter, firstVerse,\nlastVerse, scriptureText) void
// }

public class Reference
{
    private string _book = "";
    private int _chapter = 0;
    private int _firstVerse = 0;
    private int _lastVerse = 0;
    private List<string> _scriptureText = new List<string>();

    public Reference(string book, int chapter, int firstVerse, int lastVerse, List<string> scriptureText)
    // Constructor for multi-verse references
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
        _scriptureText = scriptureText;
    }

    public Reference(string book, int chapter, int firstVerse, string scriptureText)
    // Constructor for references with only one verse
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = firstVerse;
        _scriptureText = new List<string>() {scriptureText};
    }

    public string GetReferenceText() {
        if (_firstVerse == _lastVerse)
        {
            return $"{_book} {_chapter}:{_firstVerse}";
        } 
        else
        {
            return $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
        }
    }

    public List<string> GetScriptureText()
    {
        // return String.Join(Environment.NewLine, _scriptureText);
        return _scriptureText;
    }

}
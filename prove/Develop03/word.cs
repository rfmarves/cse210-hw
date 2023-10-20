// class Word {
// 	- _wordText : string
// 	- _isHidden : boolean
// 	+ Hide() void
// 	+ Show() void
// 	+ IsHidden() boolean
// 	+ GetRenderedText() string
// 	+ Word(wordText, isHidden=False) void
// }

public class Word
{
    private string _wordText = "";
    private Boolean _isHidden = false;

    public Word(string wordText, Boolean isHidden = false)
    {
        _wordText = wordText;
        _isHidden = isHidden;
    }

    public Boolean IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public string GetRenderedText()
    {
        if (_isHidden)
        {
            // string _stringOut = "";
            // foreach (char c in _wordText)
            // {
            //     if (char.IsLetter(c) || c.CompareTo("\'")==0 ) 
            //     {
            //         _stringOut += "_";
            //     }
            //     else
            //     {
            //         _stringOut += c;
            //     }
            // }
            // return _stringOut;
            if (_wordText.EndsWith(Environment.NewLine))
            {
                return new string('_', _wordText.Length - 1) + Environment.NewLine;
            }
            else
            {
                return new string('_', _wordText.Length);
            }
        }
        else
        {
            return _wordText;
        }
    }
}
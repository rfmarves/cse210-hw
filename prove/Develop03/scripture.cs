// class Scripture {
// 	- _wordsInScripture : list~Word~
// 	- _Reference : Reference
// 	+ HideWords() void
// 	+ GetRenderedText() string
// 	+ IsCompletelyHidden() boolean
// 	+ Scripture(reference) void
// }

public class Scripture
{
    private List<Word> _wordsInScripture = new List<Word>();
    private string _reference = "";

    public Scripture(Reference reference)
    {
        _reference = reference.GetReferenceText();
        foreach (string verse in reference.GetScriptureText())
        {
            string[] words = verse.Split(" ");
            string lastWord = words.Last();
            foreach (string w in words)
            {
                if (w.Equals(lastWord))
                {
                    _wordsInScripture.Add(new Word(w + Environment.NewLine));
                }
                else
                {
                    _wordsInScripture.Add(new Word(w));
                }
            }
        }
    }

    public Boolean IsCompletelyHidden()
    {
        Boolean allHidden = true;
        int i = 0;
        while (allHidden && i < _wordsInScripture.Count)
        {
            if(!_wordsInScripture[i].IsHidden())
            {
                allHidden = false;
            }
            i++;
        }
        return allHidden;
    }

    public void GetRenderedText()
    {
        Console.Write(_reference + "  ");
        foreach (var w in _wordsInScripture)
        {
            Console.Write(w.GetRenderedText());
            Console.Write(" ");
        }
    }

    public void HideWords()
    {
        var rnd = new Random();
        List<int> visibleWords = new();
        int r = 0;
        for (int i = 0; i < _wordsInScripture.Count; i++)
        {
            if(!_wordsInScripture[i].IsHidden())
            {
                visibleWords.Add(i);
            }
        }
        int j = 0;
        while((j<3) && (visibleWords.Count>0))
        {
            r = rnd.Next(visibleWords.Count);
            _wordsInScripture[visibleWords[r]].Hide();
            visibleWords.RemoveAt(r);
            j++;
        }
    }

    public void UnhideAll()
    {
        foreach (var word in _wordsInScripture)
        {
            word.Show();
        }
    }

}
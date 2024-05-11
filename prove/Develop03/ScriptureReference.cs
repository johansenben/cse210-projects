class ScriptureReference
{
    private string _book;
    private int _chapter;
    private string _verses;

    //1 verse
    public ScriptureReference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verses = $"{verse}";
    }

    //range of verses
    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verses = $"{startVerse}-{endVerse}";
    }

    //verses part of reference is a string
    public ScriptureReference(string book, int chapter, string verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }

    //list of verse numbers
    public ScriptureReference(string book, int chapter, int[] verses)
    {
        _book = book;
        _chapter = chapter;
        string versesString = "";
        for (int i = 0; i < verses.Length; i++) 
        {
            versesString += verses[i];
            if (i < verses.Length - 1)
                versesString += ',';
        }
        _verses = versesString;
    }

    public string GetReferenceText()
    {
        return $"{_book} {_chapter}: {_verses}";
    }
}
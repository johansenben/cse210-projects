class Scripture
{
    private static readonly string IGNORE_WORD_WITH_PREFIX = "%";
    public static string GetIgnoreWordPrefix()
    {
        return IGNORE_WORD_WITH_PREFIX;
    }

    private ScriptureReference _reference;
    private List<List<ScriptureWord>> _words = new List<List<ScriptureWord>>();
    private int _totalWords;
    private int _totalVisibleWords;

    public Scripture(ScriptureReference reference, string[] verses)
    {
        _reference = reference;

        InitVerses(verses);
    }
    public Scripture(ScriptureReference reference, string verse)
    {
        _reference = reference;
        InitVerses([verse]);
    }
    private void InitVerses(string[] verses)
    {
        _totalWords = 0;

        int verseNum = 0;
        foreach (string verse in verses)
        {
            _words.Add(new List<ScriptureWord>());
            string[] words = verse.Split(' ');
            foreach (string word in words)
            {
                if (word.Length >= IGNORE_WORD_WITH_PREFIX.Length &&  word.Substring(0, IGNORE_WORD_WITH_PREFIX.Length) == IGNORE_WORD_WITH_PREFIX) //words that can't be replaced by blanks
                {
                    _words[verseNum].Add(new ScriptureWord(word.Replace(IGNORE_WORD_WITH_PREFIX, ""), false));
                }
                else
                {
                    _words[verseNum].Add(new ScriptureWord(word, true));
                    _totalWords++;
                }
            }
            verseNum++;
        }

        _totalVisibleWords = _totalWords;
    }

    public ScriptureReference GetReference()
    {
        return _reference;
    }
    
    public void DisplayScripture(bool clearConsole = true, bool showBlanks = true)
    {
        //clear console or create a space using a new line
        if (clearConsole)
            Console.Clear();
        else
            Console.WriteLine();

        Console.WriteLine(_reference.GetReferenceText());
        foreach (List<ScriptureWord> verse in _words)
        {
            foreach (ScriptureWord word in verse)
            {
                if (showBlanks)
                    Console.Write($"{word.GetDisplayWord()} "); //can print as a blank if the word is hidden
                else
                    Console.Write($"{word.GetWord()} "); //never prints as a blank
            }
            Console.WriteLine();//new line between verses
        }
        Console.WriteLine();
    }
    public void HideWords(int count = 1)
    {
        if (count > _totalVisibleWords)//prevents infinite loop
            count = _totalVisibleWords;
        int totalVerses = _words.Count;
        Random rand = new Random();
        for (int i = 0; i < count; i++)
        {
            while (_totalVisibleWords > 0)
            {
                int verseIndex = rand.Next(totalVerses);
                int totalWords = _words[verseIndex].Count;
                int wordIndex = rand.Next(totalWords);

                ScriptureWord word = _words[verseIndex][wordIndex];

                if (word.GetCanBeHidden() && !word.GetIsHidden())
                {
                    word.Hide();
                    _totalVisibleWords--;
                    break;
                }
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        return _totalVisibleWords <= 0;
    }

}
class Memorizer 
{
    private List<Scripture> _scriptures = new List<Scripture>();

    public Memorizer()
    {   
        SetupScriptures();
    }

    private void SetupScriptures()
    {
        AddScripture(new ScriptureReference("1 Nephi", 3, 7), 
            "%7. And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, " +
            "for I know that the Lord giveth no commandment unto the children of men, " +
            "save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
        );
        AddScripture(new ScriptureReference("John", 3, 16), 
            "%16. For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        );
        AddScripture(new ScriptureReference("John", 13, 34, 35), [
            "%34. A new commandment I give unto you, That ye love one another; as I have loved you, that ye also love one another.",
            "%35. By this shall all men know that ye are my disciples, if ye have love one to another."
        ]);
        AddScripture(new ScriptureReference("3 Nephi", 14, 7, 8), [
            "%7. Ask, and it shall be given you; seek and ye shall find; knock and it shall be opened unto you.",
            "%8. For every one that asketh, recieveth; and he that seeketh, findeth;band to him that knocketh, it shall be opened."
        ]);
        AddScripture(new ScriptureReference("D&C", 4, 2), 
            "%2. Therefore, O ye that embark in the service of Gof, see that ye serve him with all your heart, might, mind and strength, that ye may stand blameless before God at the last day."
        );
        AddScripture(new ScriptureReference("D&C", 82, 10), 
            "%10. I, the Lord, am bound when ye do what I say; but when ye do not what I say, ye have no promise."
        );
    }
    //2+ verses
    private void AddScripture(ScriptureReference reference, string[] verses)
    {
        _scriptures.Add(new Scripture(reference, verses));
    }
    //1 verse
    private void AddScripture(ScriptureReference reference, string verse)
    {
        _scriptures.Add(new Scripture(reference, verse));
    }

    //chooses a random scripture
    private Scripture GetRandomScripture() 
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }

    //user picks a number that corresponds to one of the stored scriptures
    private int PickScripture()
    {
        Console.WriteLine("What scripture Do you want to memorize?");
        for(int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scriptures[i].GetReference().GetReferenceText()}");
        }
        bool isInt = int.TryParse(Console.ReadLine(), out int index);
        if (isInt)
        {
            return index;
        }
        return -1;
        
    }

    //the user inputs all of the information for the scriptures
    private Scripture InputScripture()
    {
        Console.WriteLine("What is the book?");
        string book = Console.ReadLine();

        Console.WriteLine("What is the chapter?");
        int.TryParse(Console.ReadLine(), out int chapter);

        Console.WriteLine("What are the verse numbers for the reference?");
        string versesRef = Console.ReadLine();

        List<string> verses = new List<string>();
        while (true)
        {
            Console.WriteLine($"Type the verse? Typing '{Scripture.GetIgnoreWordPrefix()}' immediately before any word will prevent it from bing replaced by a blank (example: '{Scripture.GetIgnoreWordPrefix()}word' will always be displayed as 'word').");
            string verse = Console.ReadLine();

            verses.Add(verse);

            Console.WriteLine("Is there another verse? (y/n)");
            if (Console.ReadLine().ToUpper() == "Y")
                continue;
            break;
        }

        return new Scripture(new ScriptureReference(book, chapter, versesRef), verses.ToArray());
    }
    private Scripture GetScripture()
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Pick A Scripture      2. Input A scripture        3. Get A Random Scripture (Default)");
        string choice = Console.ReadLine();

        switch (choice) 
        {
            case "1":
                int index = PickScripture() - 1;
                if (index < 0 || index >= _scriptures.Count)
                    return GetRandomScripture();
                return _scriptures[index];
            case "2":
                return InputScripture();
            default:
                return GetRandomScripture();
        }
    }
    public void ManageIO()
    {
        Scripture scripture = GetScripture();

        scripture.DisplayScripture();

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press enter to continue or type quit (default) to exit.");
            string input = Console.ReadLine();
            if (input != "")
                break;

            scripture.HideWords(2);
            scripture.DisplayScripture();
            
        }
    }
}
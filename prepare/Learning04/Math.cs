class Math : Assignment
{
    private string _textbookSection;
    private string _problems;

    public Math(string name, string topic, string textbookSection, string problems) : base(name, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetTextbookSection()
    {
        return _textbookSection;
    }
    public void SetTextbookSection(string section)
    {
        _textbookSection = section;
    }
    public string GetProblems()
    {
        return _problems;
    }
    public void SetProblems(string problems)
    {
        _problems = problems;
    }

    public string GetHomework()
    {
        return $"{_textbookSection} {_problems}";
    }
}
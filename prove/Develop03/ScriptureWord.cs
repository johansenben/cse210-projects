class ScriptureWord 
{
    private bool _isHidden = false;
    private bool _canBeHidden;
    private string _word;

    public ScriptureWord(string word, bool canBeHidden = true)
    {
        _word = word;
        _canBeHidden = canBeHidden;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }
    
    public void Hide()
    {
        _isHidden = true;
    }

    public bool GetCanBeHidden()
    {
        return _canBeHidden;
    }

    public string GetWord()
    {
        return _word;
    }
    public string GetDisplayWord()
    {
        if (_isHidden)
            return new string('_', _word.Length);
        else
            return _word;
    }
}
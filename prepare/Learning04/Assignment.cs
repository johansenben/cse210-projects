class Assignment
{
    private string _name;
    private string _topic;

    public Assignment(string name, string topic)
    {
        _name = name;
        _topic = topic;
    }

    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetTopic()
    {
        return _topic;
    }
    public void StTopic(string topic)
    {
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"Name: {_name}, Topic: {_topic}";
    }
}
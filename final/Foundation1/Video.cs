class Video
{
    private string _title;
    private string _author;
    private string _description;
    private int _length; //in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int seconds, string description = "")
    {
        _title = title;
        _author = author;
        _length = seconds;
        _description = description;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    private string GetTimeString()
    {
        int seconds = _length % 60;
        int minutes = _length / 60 % 60;
        int hours = _length / 3600;
        return $"{(hours < 10 ? '0' : "")}{hours}:{(minutes < 10 ? '0' : "")}{minutes}:{(seconds < 10 ? '0' : "")}{seconds}";
    }
    public int GetSeconds()
    {
        return _length;
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
    public void Display()
    {
        Console.WriteLine(_title);
        Console.WriteLine($"Author: {_author}        Time: {GetTimeString()} ({_length} seconds)");
        Console.WriteLine($"{_description}");
        Console.WriteLine($"Comments:               Total: {GetCommentCount()}");
        foreach (Comment comment in _comments)
            comment.Display();
    }
    public void DisplayHeader()
    {
        Console.WriteLine($"{_title} by {_author}: {GetTimeString()}, {GetCommentCount()} comments");
    }

    public List<Comment> SearchForComment(string containsString)
    {
        List<Comment> commentsFound = new List<Comment>();
        foreach (Comment comment in _comments)
        {
            if (comment.CommentContains(containsString))
                commentsFound.Add(comment);
        }
        return commentsFound;
    }
}
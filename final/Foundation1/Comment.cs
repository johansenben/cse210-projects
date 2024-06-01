class Comment
{
    private string _commenterName;
    private string _date;
    private string _comment;

    public Comment(string commenterName, string comment, string date = null)
    {
        _commenterName = commenterName;
        _comment = comment;
        _date = date ?? DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"{_commenterName}  ......  {_date}");
        Console.WriteLine($"\t{_comment}");
    }
    public bool CommentContains(string str)
    {
        return _comment.Contains(str);
    }
}
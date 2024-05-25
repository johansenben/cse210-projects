abstract class Goal
{
    private string _name;
    private string _description;

    protected Goal(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName()
    {
        return _name;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }

    public void Display(bool printStats = true)
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        Console.WriteLine($"{checkBox} Goal: {_name}, Description: {_description}");
        if (printStats)
            DisplayStatistics();
    }
    
    //used to report on the goal and say if the goal/daily task was completed
    //returns the points awarded for that day
    public abstract int DayFinished(bool taskCompletedToday);
    public abstract bool IsComplete();
    public abstract void DisplayStatistics();
    
    //gets value to be saved as a line in a text file
    public abstract string GetSaveString();
    public abstract void LoadFromString(string str);
    
}
class EternalGoal : Goal
{
    private int _pointsPerDay; //points awarded for daily task completion
    private int _totalCompletions = 0; //number of daily completions
    private int _streak = 0; //number of daily completions in a row

    public EternalGoal(string name, string description) : base(name, description)
    {
        InitUsingInputs();
    }
    public EternalGoal(string name, string description, int pointsPerDay) : base(name, description)
    {
        _pointsPerDay = pointsPerDay;
    }
    public EternalGoal(string strFromSave): base("", "") //defaults are empty strings
    {
        LoadFromString(strFromSave);
    }
    private void InitUsingInputs()
    {
        //_pointsPerDay
        Console.WriteLine("How many points should be awarded for each daily completion?");
        //only possitive integers are allowed
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input > 0)
                    _pointsPerDay = input;
                    break;
            }
            Console.WriteLine("Input must be a positive integer!");
        }
    }

    public override int DayFinished(bool taskCompletedToday)
    {
        if (taskCompletedToday)
        {
            _streak++;
            _totalCompletions++;
        }
        else
            _streak = 0;
        return taskCompletedToday ? _pointsPerDay : 0;
    }

    public override void DisplayStatistics()
    {
        Console.WriteLine($"\tTotal Completions: {_totalCompletions}, Streak: {_streak}");
    }

    public override bool IsComplete()
    {
        return false; //goal can never be completed
    }

    public override string GetSaveString()
    {
        //"SimpleGoal,<name>,<description>,<pointsPerDay>,<totalCompletions>,<streak>"
        return $"EternalGoal,{GetName()},{GetDescription()},{_pointsPerDay},{_totalCompletions},{_streak}";
    }

    public override void LoadFromString(string str)
    {
        int ToInt(string s)
        {
            bool isInt = int.TryParse(s, out int num);
            return isInt ? num : 0;
        }
        string[] separated = str.Split(",");
        SetName(separated[1]);
        SetDescription(separated[2]);
        _pointsPerDay = ToInt(separated[3]);
        _totalCompletions = ToInt(separated[4]);
        _streak = ToInt(separated[5]);
    }
}
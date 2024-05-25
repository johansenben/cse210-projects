class SimpleGoal : Goal
{
    private bool _isCompleted = false;
    private int _pointsForCompletion; //points awarded when goal is completed
    public SimpleGoal(string name, string description) : base(name, description)
    {
        //_pointsForCompletion must be a positive integer
        while (true){
            Console.WriteLine("How many points are required to complete the goal? ");
            if (int.TryParse(Console.ReadLine(), out int points))
            {
                if (points > 0)
                {
                    _pointsForCompletion = points;
                    break;
                }
            }
            Console.WriteLine("Input must be a positive integer!");
        }
    }
    public SimpleGoal(string name, string description, int pointsForCompletion) : base(name, description)
    {
        _pointsForCompletion = pointsForCompletion;
    }
    public SimpleGoal(string strFromSave): base("", "") //defaults are empty strings
    {
        LoadFromString(strFromSave);
    }

    public override void DisplayStatistics()
    {
        //do nothing because goal is too simple to display any statistics
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override int DayFinished(bool wasTaskCompletedToday)
    {
        if (!_isCompleted)
        {
            _isCompleted = wasTaskCompletedToday;
            return wasTaskCompletedToday ? _pointsForCompletion : 0;
        }
        return 0; //no points after goal is completed
    }

    public override string GetSaveString()
    {
        //"SimpleGoal,<name>,<description>,<isComplete>,<pointsForCompletion>"
        return $"SimpleGoal,{GetName()},{GetDescription()},{_isCompleted},{_pointsForCompletion}";
    }

    public override void LoadFromString(string str)
    {
        string[] separated = str.Split(",");
        SetName(separated[1]);
        SetDescription(separated[2]);
        _isCompleted = separated[3] == "True";
        bool isInt = int.TryParse(separated[4], out int pts);
        _pointsForCompletion = isInt ? pts : 0;
    }
}
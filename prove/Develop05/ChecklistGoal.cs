class ChecklistGoal : Goal
{
    private int _completionsRequired; //goal is completed when this number of daily tasks are completed

    private int _pointsOnCompletion; //points awarded on completion

    private int _dailyPoints; //points awarded for daily task completion

    private int _streak = 0; //number of daily completions in a row
    private float _streakBonusMultiplier; //when daily task completed -> bonus points: _streak * _streakBonusMultiplier

    private int _totalCompletions = 0; //number of daily completions
    private float _completionBonusMultiplier; //when daily task completed -> bonus points: _totalCompletions * _completionBonusMultipler

    public ChecklistGoal(string name, string description) : base(name, description)
    {
        InitUsingInputs();
    }
    public ChecklistGoal(string name, string description, int dailyPoints, float streakBonusMultiplier, float completionBonusMultiplier, int completionsRequired, int pointsOnCompletion) : base(name, description)
    {
        _dailyPoints = dailyPoints;
        _streakBonusMultiplier = streakBonusMultiplier;
        _completionBonusMultiplier = completionBonusMultiplier;
        _completionsRequired = completionsRequired;
        _pointsOnCompletion = pointsOnCompletion;
    }
    public ChecklistGoal(string strFromSave): base("", "") //defaults are empty strings
    {
        LoadFromString(strFromSave);
    }
    private void InitUsingInputs()
    {
        //call Console.Readline until user types a positive integer
        int InputPositiveInt(){
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input > 0)
                        return input;
                }
                Console.WriteLine("Input must be a positive integer!");
            }
        }
        //call Console.Readline until user types a positive float
        float InputPositiveFloat(){
            while (true)
            {
                try
                {
                    float input = float.Parse(Console.ReadLine());
                    if (input > 0)
                        return input;
                }
                catch {}
                Console.WriteLine("Input must be a positive decimal number!");
            }
        }

        //_dailyPoints
        Console.WriteLine("How many points should be recieved each day that the task is completed?");
        _dailyPoints = InputPositiveInt();

        //_strealBonusMultiplier
        Console.WriteLine("What is the streak bonus points multiplier? If it is 1.5 and the streak is 2, 3 bonus points will be awarded if the daily task is completed.");
        _streakBonusMultiplier = InputPositiveFloat();

        //_completionBonusMultiplier
        Console.WriteLine("What is the completion bonus points multiplier? If it is 1.5 and the 2 daily goals have been completed, 3 bonus points will be awarded if the daily task is completed.");
        _completionBonusMultiplier = InputPositiveFloat();

        //_completionsRequired
        Console.WriteLine("How many daily completions are required to complete the goal?");
        _completionsRequired = InputPositiveInt();

        //_pointsOnCompletion
        Console.WriteLine("How many points should be awarded for completing the goal?");
        _pointsOnCompletion = InputPositiveInt();
    }

    public override int DayFinished(bool taskCompletedToday)
    {
        if (!IsComplete())
        {
            int completionPoints = 0;
            int dailyPoints = 0;
            int streakPoints = 0; //bonus is onlygiven if daly task is completed
            int completionBonusPoints = 0; //bonus is onlygiven if daly task is completed
            if (taskCompletedToday)
            {
                _streak++;
                _totalCompletions++;
                completionPoints = _pointsOnCompletion;
                dailyPoints = _dailyPoints;
                streakPoints = (int)(_streak * _streakBonusMultiplier);
                completionBonusPoints = (int)(_totalCompletions * _completionBonusMultiplier);
            }
            else
                _streak = 0;
            

            return dailyPoints + streakPoints + completionBonusPoints + completionPoints;
        }
        return 0; //no points after the goal is already completed
    }

    public override void DisplayStatistics()
    {
        Console.WriteLine($"\tTotal Completions: {_totalCompletions}, Streak: {_streak}");
    }

    public override bool IsComplete()
    {
        return _totalCompletions >= _completionsRequired;
    }

    public override string GetSaveString()
    {
        //"ChecklistGoal,<name>,<description>,<completionsRequired>,<pointsOnCompletion>,<dailyPoints>,<streak>,<streakBonusMultiplier>,<totalCompletions>,<completionBonusMultipler>"
        return $"ChecklistGoal,{GetName()},{GetDescription()},{_completionsRequired},{_pointsOnCompletion},{_dailyPoints},{_streak},{_streakBonusMultiplier},{_totalCompletions},{_completionBonusMultiplier}";
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
        _completionsRequired = ToInt(separated[3]);
        _pointsOnCompletion = ToInt(separated[4]);
        _dailyPoints = ToInt(separated[5]);
        _streak = ToInt(separated[6]);
        _streakBonusMultiplier = ToInt(separated[7]);
        _totalCompletions = ToInt(separated[8]);
        _completionBonusMultiplier = ToInt(separated[9]);
    }
}
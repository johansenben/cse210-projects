class ProgressTracker
{
    private int _score;
    private List<Goal> _goals = new List<Goal>();

    public ProgressTracker()
    {
        _score = 0;
    }

    private void AddGoal()
    {
        //which type of goal?
        Console.WriteLine("Which goal type do you want to add?");
        Console.WriteLine("1. Simple: Can only be completed once and points are awarded on completion.");
        Console.WriteLine("2. Eternal: Can never be completed, but has a task that is attempted daily.");
        Console.WriteLine("3. Checklist: A specific number af daily tasks are completed before the task is completed. This option allows for bonus points based on the streak or total completed tasks.");
        Console.WriteLine("4. Cancel: Don't add a goal.");
        string choice = Console.ReadLine();
        //don't add goal if input is invalid or '4. Cancel'
        if (choice != "1" && choice != "2" && choice != "3")
            return;

        //name
        Console.WriteLine("What is the name of the goal?");
        string name = Console.ReadLine();

        //description
        Console.WriteLine("What is the description of the goal?");
        string description = Console.ReadLine();

        //add the goal
        switch (choice)
        {
            case "1": //simple
                _goals.Add(new SimpleGoal(name, description));
                break;
            case "2": //eternal
                _goals.Add(new EternalGoal(name, description));
                break;
            case "3": //checklist
                _goals.Add(new ChecklistGoal(name, description));
                break;
        }
    }
    private void ReportGoal()
    {
        Console.WriteLine("Which goal do you want to report on?");
        //print list of goals with number
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].Display(false);
        }
        //prompt the user until valid number is inputted
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (input > 0 && input <= _goals.Count)
                {
                    Console.WriteLine("Was the goal or daily task completed? Y/N");
                    int scoreIncrease = _goals[input - 1].DayFinished(Console.ReadLine().ToUpper() == "Y");
                    AddScore(scoreIncrease);

                    //completion message
                    if (_goals[input - 1].IsComplete())
                        Console.WriteLine("Congratulations! You completed the goal!");

                    //points awarded message
                    if (scoreIncrease == 0)
                        Console.WriteLine("No points were awarded");
                    else
                        Console.WriteLine($"{scoreIncrease} points were awarded!");

                    return;
                }
            }
            Console.WriteLine("Input must be one of the numbers displayed!"); //only if invalid number is inputted
        }
    }
    private void AddScore(int scoreIncrease)
    {
        _score += scoreIncrease;
    }
    private void Display()
    {
        Console.WriteLine($"Score: {_score}");
        foreach (Goal goal in _goals)
            goal.Display();
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the name of the txt file? (without '.txt')");
        string fileName = Console.ReadLine() + ".txt";
        
        using (StreamWriter file = new StreamWriter(fileName))
        {
            //score
            file.WriteLine($"{_score}");

            //goals
            foreach (Goal goal in _goals)
            {
                file.WriteLine(goal.GetSaveString());
            }
        }
    }
    public void LoadGoals()
    {
        //reset goals before lading new ones
        _goals.Clear();

        Console.WriteLine("What is the name of the txt file? (without '.txt')");
        string fileName = Console.ReadLine() + ".txt";

        string[] lines = System.IO.File.ReadAllLines(fileName);

        //score
        bool isInt = int.TryParse(lines[0], out int score);
        _score = isInt ? score : 0;

        for (int i = 1; i < lines.Length; i++)
        {
            System.Text.RegularExpressions.Regex typePattern = new System.Text.RegularExpressions.Regex("^([^,]+)");
            string type = typePattern.Match(lines[i]).ToString();

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(lines[i]));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(lines[i]));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(lines[i]));
                    break;
            }
        }
    }

    public void HandleIO()
    {
        bool brk = false;//used to break out of while loop from within the switch statement
        while (!brk)
        {
            //prompt user about what to do
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Add New Goal");
            Console.WriteLine("2. Report Progress");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit (Default)");

            switch (Console.ReadLine())
            {
                case "1": //add
                    AddGoal();
                    break;
                case "2": //report
                    ReportGoal();
                    break;
                case "3": //display
                    Display();
                    break;
                case "4": //save
                    SaveGoals();
                    break;
                case "5": //load
                    LoadGoals();
                    break;
                default: //quit
                    brk = true;
                    break;
            }

        }
    }
}
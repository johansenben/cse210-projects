class BreathingActivity : Activity
{
    private int _breathTime;
    public BreathingActivity(int breathTime) : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _breathTime = breathTime;
    }

    public override void HandleActivity()
    {
        string[] pauseFrames = ["   ", ".  ", ".. ", "..."];

        Console.Clear();
        PrintStartMessage();
        Console.WriteLine();
        PrintDecription();
        Console.WriteLine();

        int totalSeconds = GetSecondsInput();
        Console.WriteLine();
        if (totalSeconds == -1) // -1 means user didn't enter a number
            return;

        Pause("The activity will start in", 5);
        Console.Clear();

        for (int time = 0; time < totalSeconds; time += _breathTime * 2)
        {
            int remainingTime = totalSeconds - time;
            int useTime = remainingTime >= _breathTime ? _breathTime : remainingTime; //if remaining time is less than _breathTime -> use remaining time
            Pause("Breathe in", useTime, 2, pauseFrames: pauseFrames);

            remainingTime = totalSeconds - time - useTime;
            if (useTime > 0) //if remaining time == 0 -> skip breathing out
            {
                useTime = remainingTime >= _breathTime ? _breathTime : remainingTime; //if remaining time is less than _breathTime -> use remaining time
                Pause("Breathe out", useTime, 2, pauseFrames: pauseFrames);
            }
        }

        Console.WriteLine();
        PrintEndMessage();
        Thread.Sleep(5000);
    }
}
abstract class Activity {
    private string _name;
    private string _description;

    public Activity(string name, string desription)
    {
        _name = name;
        _description = desription;
    }


    public void Pause(string message, int seconds, int pauseFramesPerSecond = 1, bool showCountDown = true, string[] pauseFrames = null)
    {
        static void Backspace(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write("\b \b");
        }

        if (pauseFrames == null || pauseFrames.Length == 0)
            pauseFrames = [""]; //if no pauseFrames parameter is specified or pauseFrames is invalid, use an empty frame

        Console.CursorVisible = false; //prevent cursor from jumping around
        
        int currentPauseFrame = 0;
        Console.Write(message);
        for (int i = seconds; i > 0; i--)
        {
            string secondsText = showCountDown ? $" {i} seconds" : "";
            
            for (int i2 = 0; i2 < pauseFramesPerSecond; i2++)
            {
                Console.Write(pauseFrames[currentPauseFrame] + secondsText);
                Thread.Sleep(1000 / pauseFramesPerSecond);

                Backspace(pauseFrames[currentPauseFrame].Length + secondsText.Length);
                
                currentPauseFrame = (currentPauseFrame + 1) % pauseFrames.Length; //increment and prevent fromgoing over max index
            }
        }
        Console.Clear();
        Console.CursorVisible = true;
    }

    public int GetSecondsInput()
    {
        int tries = 0;
        while (tries < 10)
        {
            Console.WriteLine("How long do you want to do the activity for?");
            bool isInt = int.TryParse(Console.ReadLine(), out int seconds);
            if (isInt && seconds >= 0)
                return seconds;
        }
        return -1; //-1 means user failed to enter a valid number
    }

    public void PrintStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
    }
    public void PrintDecription()
    {
        Console.WriteLine(_description);
    }
    public void PrintEndMessage()
    {
        Console.WriteLine($"Thanks for doing the {_name} activity!");
    }
    abstract public void HandleActivity();
}
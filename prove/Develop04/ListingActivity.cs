class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on things in your life by listing as many things as you can about a prompt.")
    {

    }

    private string GetRandomPrompt()
    {
        string[] prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];

        Random rnd = new Random();
        int index = rnd.Next(0, prompts.Length);
        return prompts[index];
    }

    private string ReadUserInput(int startSeconds)
    {
        System.Text.RegularExpressions.Regex validChars = new System.Text.RegularExpressions.Regex("[0-9a-zA-z,.;:'\"/()!@#$%^&*_+=-`~]");

        TimeSpan time = DateTime.Now - DateTime.Now;
        TimeSpan lastTimeSpan = DateTime.Now - DateTime.Now;
        string lastText = $"({startSeconds}) ";
        DateTime lastTime = DateTime.Now;
        string line = "";
        ConsoleKeyInfo? keyPressed = null;
        Console.Write($"({startSeconds}) ");
        bool keyTyped = false;
        while (keyPressed == null || keyPressed?.Key != ConsoleKey.Enter)
        {
            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(true);
                if (validChars.Match($"{keyPressed?.KeyChar}").Length > 0)
                {
                    line += keyPressed?.KeyChar;
                    keyTyped = true;
                }
            }
            if (time.Seconds == lastTimeSpan.Seconds || keyTyped)
            {
                for (int i = 0; i < lastText.Length; i++)
                {
                    Console.Write("\b \b");
                }
                lastText = $"({startSeconds - lastTimeSpan.Seconds}) {line}";
                Console.Write(lastText);
                keyTyped = false;
            }

            DateTime currentTime = DateTime.Now;
            lastTimeSpan = time;
            time += currentTime.TimeOfDay - lastTime.TimeOfDay;
            lastTime = currentTime;

            if (time.Seconds >= startSeconds)
                break;
            Thread.Sleep(1000 / 10); //limit to about 10 itterations per second
        }
        for (int i = 0; i < lastText.Length; i++)
        {
            Console.Write("\b \b");
        }
        return line;
    }

    private List<string> GetPromptResponses(int totalSeconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(totalSeconds);

        List<string> inputs = new List<string>();
        while (DateTime.Now < endTime)
        {
            DateTime currentTime = DateTime.Now;
            int secondsLeft = (endTime - currentTime).Seconds;
            if (secondsLeft > 0)
            {
                string input = ReadUserInput(secondsLeft);
                if (input != "")
                    inputs.Add(input);
            }
        }

        return inputs;
    }
    public override void HandleActivity()
    {

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

        string prompt = GetRandomPrompt();
        Pause($"Consider the prompt: {prompt}", 10);

        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Type as many responses to the prompt as you can.");

        List<string> inputs = GetPromptResponses(totalSeconds);

        Console.WriteLine($"Total Responses: {inputs.Count}");
        Console.WriteLine();
        PrintEndMessage();
        Thread.Sleep(5000);
    }
}
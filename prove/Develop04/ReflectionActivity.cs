class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in your life.")
    {

    }

    private string GetRandomPrompt()
    {
        string[] prompts = [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];

        Random rnd = new Random();
        int index = rnd.Next(0, prompts.Length);
        return prompts[index];
    }
    private string GetRandomQuestion()
    {
        string[] questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];
        Random rnd = new Random();
        int index = rnd.Next(0, questions.Length);
        return questions[index];
    }

    public override void HandleActivity()
    {
        string[] pauseFrames = ["/","|","\\","-"];

        Console.Clear();
        PrintStartMessage();
        Console.WriteLine();
        PrintDecription();
        Console.WriteLine();

        int totalSeconds = GetSecondsInput();
        Console.WriteLine();
        if (totalSeconds == -1) // -1 means user didn't enter a number
            return;

        Pause("Activity will start in", 5);
        Console.Clear();

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.WriteLine($"Prompt: {prompt}");
        Pause("", 5, 4, pauseFrames: pauseFrames);

        int secondsPerQuestion = 10;


        for (int timeLeft = totalSeconds; timeLeft > 0; timeLeft -= secondsPerQuestion)
        {
            Console.Clear();
            Console.WriteLine($"Prompt: {prompt}");

            string question = GetRandomQuestion();
            Console.WriteLine($"Question: {question}");

            int useTime = timeLeft <= secondsPerQuestion ? timeLeft : secondsPerQuestion;
            Pause("", useTime, 4, pauseFrames: pauseFrames);
        }

        Console.WriteLine();
        PrintEndMessage();
        Thread.Sleep(5000);
    }
}
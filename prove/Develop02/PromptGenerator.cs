
class PromptGenerator {
    private string[] _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        
        "What did I do today?",
        "Did I learn anything new today? What did I learn?",
        "What was I grateful for today?",
        "How did I serve someone today?",
        "On a scale of 1 to 10, how was my day? Why?",
        "Did something new or different happen today?"
    ];

    public string GetPrompt() {
        Random random = new Random();
        int promptIndex = random.Next(0, _prompts.Length);
        return _prompts[promptIndex]; 
    }
}
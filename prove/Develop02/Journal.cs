
public class Journal
{
    List<JournalEntry> _entries = new List<JournalEntry>();
    PromptGenerator _promptGenerator = new PromptGenerator();

    public void NewEntry()
    {
        //get prompt and display it
        string prompt = _promptGenerator.GetPrompt();
        Console.WriteLine(prompt);

        //get entry
        Console.Write("Entry Text: ");
        string text = Console.ReadLine();

        //get date
        DateTime theCurrentTime = DateTime.Now;
        string date = theCurrentTime.ToShortDateString();

        //add the entry to the list of entries
        AddEntry(text, date, prompt);
    }
    public void AddEntry(string text, string date, string prompt) //use constructor that takes text,date,prompt
    {
        _entries.Add(new JournalEntry(text, date, prompt));
    }
    public void AddEntry(string csvLine) //use constructor that takes csvLine
    {
        _entries.Add(new JournalEntry(csvLine));
    }

    private static bool DoesJournalExist(string fileName)//check if file exists and if it has more than a header
    {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            if (lines.Length > 1) //check if there are any entries saved
                return true;
        }
        catch {}
        return false;
    }
    public void Save(string fileName)
    {
        //Append or Replace? default = append
        bool append = false;
        if (DoesJournalExist(fileName))
        {
            Console.WriteLine("Do you want to append the entries to the saved journal?");
            Console.WriteLine("1. Append (Default)       2. Replace");
            string choice = Console.ReadLine();
            if (choice != "2")
                append = true;
        }
        try
        {
            using (StreamWriter file = new StreamWriter(fileName, append))
            {
                if (!append)
                {
                    file.WriteLine("date,prompt,entry,"); //only add a header if there are no previous entries
                }
                foreach (JournalEntry entry in _entries)
                {
                    string csvLine = entry.GetEntryAsCSV();
                    file.WriteLine(csvLine);
                }
            }
        }
        catch (Exception e)
        {
            if (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error with saving to '{fileName}'");
                Console.ResetColor();
            }
            else
                throw;
        }
    }
    public void Load(string fileName)
    {
        try
        {
            //Append or Replace? default = append
            if (_entries.Count > 0)
            {
                Console.WriteLine("Do you want to append the entries to the current journal?");
                Console.WriteLine("1. Append (Default)       2. Replace");
                string choice = Console.ReadLine();
                if (choice == "2")
                    _entries.Clear(); //if replace -> remove all entries from the list of entries
            }

            string[] lines = System.IO.File.ReadAllLines(fileName);
            bool isFirstLine = true;
            foreach (string line in lines)
            {
                if (isFirstLine) //skip header
                {
                    isFirstLine = false;
                    continue;
                }
                
                AddEntry(line);
            }
        }
        catch (Exception e)
        {
            if (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"File '{fileName}' Doesn't exist!");
                Console.ResetColor();
            }
            else
                throw;
        }
    }

    public void Display()
    {
        foreach (JournalEntry entry in _entries)
            entry.Display();
    }
}
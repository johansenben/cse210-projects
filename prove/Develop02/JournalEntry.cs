
public class JournalEntry
{
    string _entryText;
    string _date;
    string _prompt;

    public JournalEntry(string text, string date, string prompt)
    {
        _entryText = text;
        _date = date;
        _prompt = prompt;
    }
    public JournalEntry(string csvLine) { //parse a csv line
        int DATE_INDEX = 0;
        int PROMPT_INDEX = 1;
        int ENTRY_INDEX = 2;

        string[] separated = csvLine.Split(',');

        //date
        _date = separated.Length > DATE_INDEX ? separated[DATE_INDEX] : "No Date";

        //prompt
        _prompt = separated.Length > PROMPT_INDEX ? separated[PROMPT_INDEX] : "No Prompt";
        _prompt = _prompt.Substring(1, _prompt.Length - 2); //remove quotes

        //entry
        _entryText = separated.Length > ENTRY_INDEX ? separated[ENTRY_INDEX] : "No Entry";
        _entryText = _entryText.Substring(1, _entryText.Length - 2); //remove quotes
    }

    public string GetEntryAsCSV() 
    {
        //format: <date>,"<prompt>","<entry>",
        return $"{_date},\"{_prompt}\",\"{_entryText}\",";
    }
    public void Display() 
    {
        /*
            format:

            Date: <date>
            Prompt: <prompt>
            Entry: <entry>
            
        */
        Console.WriteLine($"\nDate: {_date}\nPrompt: {_prompt}\nEntry: {_entryText}\n");
    }
}
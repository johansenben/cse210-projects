using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        ActionsMenu(journal);
    }

    public static void ActionsMenu(Journal journal)
    {
        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Load journal from a CSV file");
            Console.WriteLine("2. Save journal to a CSV file");
            Console.WriteLine("3. Read journal");
            Console.WriteLine("4. Write a new journal entry");
            Console.WriteLine("5. Quit (default)");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("What is the name of the csv file to load the journal from (without .csv at end)? ");
                    string loadPath = Console.ReadLine();
                    journal.Load($"{loadPath}.csv");
                    break;
                case "2":
                    Console.Write("What is the name of the csv file to save the journal at (without .csv at end)? ");
                    string savePath = Console.ReadLine();
                    journal.Save($"{savePath}.csv");
                    break;
                case "3":
                    journal.Display();
                    break;
                case "4":
                    journal.NewEntry();
                    break;
                default:
                    return;
            }
        }
    }
}
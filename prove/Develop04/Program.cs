/*
Exceeds Requirements
-It keeps track of how many times each activity is done and displays it at the end
-In the listing activity, I rewrote Console.ReadLine, so it can display a coundown, while allowing the user to input text
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        (int breathing, int reflection, int listing) activityCounts = (0,0,0);

        bool brk = false;
        while (!brk)
        {
            Console.Clear();
            string activity = ChooseActivity();
            switch (activity)
            {
                case "Breathing":
                    activityCounts.breathing++;
                    BreathingActivity breathingActivity = new BreathingActivity(3);
                    breathingActivity.HandleActivity();
                    break;
                case "Reflection":
                    activityCounts.reflection++;
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.HandleActivity();
                    break;
                case "Listing":
                    activityCounts.listing++;
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.HandleActivity();
                    break;
                case "Quit":
                    brk = true;
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine($"Breathing: Completed {activityCounts.breathing} time{(activityCounts.breathing == 1 ? ' ' : 's')}");
        Console.WriteLine($"Reflection: Completed {activityCounts.reflection} time{(activityCounts.reflection == 1 ? ' ' : 's')}");
        Console.WriteLine($"Listing: Completed {activityCounts.listing} time{(activityCounts.listing == 1 ? ' ' : 's')}");
    }

    public static string ChooseActivity()
    {
        Console.WriteLine("Which activity do you want to do?");
        Console.WriteLine("1. Breathing    2. Reflection    3. Listing    4. Quit (Default)");
        
        switch (Console.ReadLine())
        {
            case "1":
                return "Breathing";
            case "2":
                return "Reflection";
            case "3":
                return "Listing";
            default:
                return "Quit";
        }
    }
}
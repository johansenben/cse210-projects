using System;

class Program
{
    static void Main(string[] args)
    {
        Lecture lecture = new Lecture("Ben Johansen", 10, "Lecture", "Lecture Description", "June 3, 2024", "7 PM", new Address("1234 1st Street", "Lethbridge", "Alberta", "Canada"));
        for (int i = 0; i < 5; i++)
            lecture.AddGuest();
        lecture.Display();

        Console.WriteLine();
        
        Reception reception = new Reception("email@gmail.com", "Reception", "Reception Description", "June 4, 2024", "8 PM", new Address("1234 1st Street", "Lethbridge", "Alberta", "Canada"));
        foreach (string name in new string[]{"name 1"})
            reception.RegisterGuest(name);
        reception.Display();

        Console.WriteLine();

        OutdoorGathering outdoorGathering = new OutdoorGathering("Sunny", "Outdoor Gathering", "Outdoor Gathering Description", "June 5, 2024", "9 PM", new Address("1234 1st Street", "Lethbridge", "Alberta", "Canada"));
        for (int i = 0; i < 5; i++)
            outdoorGathering.AddGuest();
        outdoorGathering.Display();
    }
}
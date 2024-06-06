using System;

class Program
{
    static void Main(string[] args)
    {
        Lecture lecture = new Lecture("Ben Johansen", 10, "Lecture", "Lecture Description; Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolor, hic.", "June 3, 2024", "7 PM", new Address("1234 1st Street", "Lethbridge", "Alberta", "Canada"));
        for (int i = 0; i < 5; i++)
            lecture.AddGuest();
        lecture.Display();

        Console.WriteLine();
        
        Reception reception = new Reception("email@gmail.com", "Reception", "Reception Description; Lorem ipsum dolor sit amet consectetur adipisicing elit. Tempore et repellat voluptatem dolore cum cumque?", "June 4, 2024", "8 PM", new Address("1234 1st Street", "Lethbridge", "Alberta", "Canada"));
        foreach (string name in new string[]{"name 1"})
            reception.RegisterGuest(name);
        reception.Display();

        Console.WriteLine();

        OutdoorGathering outdoorGathering = new OutdoorGathering("Sunny", "Outdoor Gathering", "Outdoor Gathering Description; Lorem ipsum dolor sit amet consectetur adipisicing elit. Maxime sint id enim? Delectus pariatur nisi mollitia nostrum quia sint culpa.", "June 5, 2024", "9 PM", new Address("1234 1st Street", "Lethbridge", "Alberta", "Canada"));
        for (int i = 0; i < 5; i++)
            outdoorGathering.AddGuest();
        outdoorGathering.Display();
    }
}
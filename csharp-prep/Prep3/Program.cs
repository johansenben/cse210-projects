using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Random random = new Random();
            int number = random.Next(1,100);
            int guesses = 0;

            while (true)
            {
                Console.Write("Guess: ");
                int guess = int.Parse(Console.ReadLine());
                guesses++;

                if (guess == number)
                {
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"{guesses} guesses");
                    break;
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
            }
            Console.Write("Do you want to continue? (y/n) ");
            string cont = Console.ReadLine();
            if (cont != "y")
            {
                break;
            }
        }
    }
}
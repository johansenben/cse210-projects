using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Random random = new Random();
            int number = random.Next(1,100);
            int totalGuesses = 0;

            while (true)
            {
                Console.Write("Guess: ");
                int guess = int.Parse(Console.ReadLine());
                totalGuesses++;

                if (guess == number)
                {
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"{totalGuesses} guesses");
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

            //replay?
            Console.Write("Do you want to continue? (y/n) ");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain != "Y" && playAgain != "YES")
            {
                break;
            }
        }
    }
}
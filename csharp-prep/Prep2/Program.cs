using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade? (0-100%)");
        string gradeText = Console.ReadLine();
        int grade = int.Parse(gradeText);

        char letter = ' ';
        if (grade >= 90) 
        {
            letter = 'A';
        }
        else if (grade >= 80) 
        {
            letter = 'B';
        }
        else if (grade >= 70) 
        {
            letter = 'C';
        }
        else if (grade >= 60) 
        {
            letter = 'D';
        }
        else if (grade < 60) 
        {
            letter = 'F';
        }

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You Passed!");
        }
        else
        {
            Console.WriteLine("You didn't pass. Better luck next time!");
        }

        string gradeSign = "";
        if (grade % 10 >= 7 && letter != 'A' && letter != 'F')
        {
            gradeSign = "+";
        }
        else if (grade % 10 < 7 && letter != 'F')
        {
            gradeSign = "-";
        }
        Console.WriteLine($"Your grade is {letter}{gradeSign}.");
    }
}
using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int squareNum = SquareNumber(num);
        DisplayResult(name, squareNum);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Name: ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Favorite Number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int num)
    {
        return num * num;
    }
    static void DisplayResult(string name, int squareNum)
    {
        Console.WriteLine($"Name: {name}, Favorite Number Squared: {squareNum}");
    }
}
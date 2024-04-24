using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers. Type 0 when you are finished.");
        while (true)
        {
            Console.Write("Enter Number: ");
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                break;
            }
            numbers.Add(num);
        }

        int sum = 0;
        int? max = null;
        int? min = null;
        foreach (int num in numbers)
        {
            //sum
            sum += num;

            //max
            if (max == null || num > max)
            {
                max = num;
            }

            //min
            if (min == null || num < min)
            {
                min = num;
            }
        }

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {(float)sum / numbers.Count}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Min: {min}");

        List<int> sorted = new List<int>();
        foreach (int num in numbers)
        {
            if (sorted.Count == 0) //if the list is empty, there are no numbers to compare with yet
            {
                sorted.Add(num);
                continue;
            }
            for (int i = 0; i < sorted.Count; i++)
            {
                if (num < sorted[i])
                {
                    sorted.Insert(i, num);
                    break;
                }
                if (i == sorted.Count - 1) //if it isn't smaller than any numbers in the list, it must be the largest
                {
                    sorted.Add(num);
                    break;
                }
            }
        }
        Console.Write("Sorted: " + string.Join(", ", sorted));
    }
}
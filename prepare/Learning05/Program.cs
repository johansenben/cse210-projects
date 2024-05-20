using System;

class Program
{
    static void Main(string[] args)
    {
        Square s = new Square(0x0000ff, 5);
        Console.WriteLine(s.GetColor());
        Console.WriteLine(s.GetArea());

        Circle c = new Circle(0xff0000, 3);
        Console.WriteLine(s.GetColor());
        Console.WriteLine(s.GetArea());
    }
}
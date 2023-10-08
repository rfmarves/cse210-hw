using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new();
        Fraction fraction2 = new(5);
        Fraction fraction3 = new(6,7);
        Fraction fraction4 = new(3,4);

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
        Console.WriteLine();
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Console.WriteLine("Hello Learning03 World!");
    }
}
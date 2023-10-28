using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning04 World!");

        MathAssignment assignment1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment1.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment assignment2 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInformation());
    }
}
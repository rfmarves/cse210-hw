using System;

class Program
{
    static void Main(string[] args)
    {
        List<float> numList = new List<float>();
        float numEntered;
        float runningTotal;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            numEntered = float.Parse(Console.ReadLine());
            if (numEntered != 0)
            {
                numList.Add(numEntered);
            }
        } while (numEntered != 0);
        Console.WriteLine($"The sum is: {numList.Sum()}");
        Console.WriteLine($"The average is: {numList.Sum()/numList.Count }");
        Console.WriteLine($"The largest number is: {numList.Max()}");
    }
}
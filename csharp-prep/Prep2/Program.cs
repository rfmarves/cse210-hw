using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter grade: ");
        string enteredGrade = Console.ReadLine();
        string letter;
        string symbol = "";

        int grade = int.Parse(enteredGrade);
        int unitsDigit = grade % 10;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else 
        {
            letter = "F";
        }
        
        if (grade >= 95)
        {
            symbol = "";
        }
        else if (grade <60)
        {
            symbol = "";
        }
        else if (unitsDigit >=7)
        {
            symbol = "+";
        }
        else if (unitsDigit < 3)
        {
            symbol = "-";
        }
 
        Console.Write($"The letter grade is {letter}{symbol}");
    }
}
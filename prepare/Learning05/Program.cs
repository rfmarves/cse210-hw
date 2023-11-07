using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
        
        List<Shape> shapes = new List<Shape> {};
        shapes.Add(new Square("blue", 5));
        shapes.Add(new Rectangle("white", 2, 8));
        shapes.Add(new Circle("yellow", 3));

        foreach (Shape s in shapes)
        {
            Console.WriteLine($"{s.GetColor()} shape with area {s.GetArea()}");
        }
    }
}
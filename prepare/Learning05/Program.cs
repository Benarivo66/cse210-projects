using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square square = new Square("white", 2.34);
        Rectangle rectangle = new Rectangle("blue", 3.4, 6.0);
        Circle circle = new Circle("red", 2.345);
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach(Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()}, {shape.GetArea()}");
        }
    }
}
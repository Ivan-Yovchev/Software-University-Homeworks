using System;

class Shapes
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        IShape[] shapes = new IShape[]
        {
            new Circle(2),
            new Circle(4.65),
            new Circle(12.678),
            new Rectangle(10, 5),
            new Rectangle(5.5, 1.234),
            new Rectangle(14.001, 9.81),
            new Triangle(16, 6),
            new Triangle(10.34, 8.1),
            new Triangle(4.25, 4.25),
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine("I am a " + shape.GetType().Name + ": " + shape.ToString());
        }

    }
}

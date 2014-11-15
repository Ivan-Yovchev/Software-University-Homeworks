using System;

class Trapezoids
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        double a, b, h;
        Console.Write("Enter side a: ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Enter side b: ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Enter height h: ");
        h = double.Parse(Console.ReadLine());

        double Area = ((a + b) / 2) * h;
        Console.WriteLine("Area: " + Area);
    }
}


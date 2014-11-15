using System;

class CirclePerimeterAndArea
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter r: ");
        double radius = double.Parse(Console.ReadLine());

        double perimiter = 2 * Math.PI * radius;
        double area = Math.PI * radius * radius;

        Console.WriteLine("Perimiter: {0:F2}",perimiter);
        Console.WriteLine("Area: {0:F2}", area);
    }
}


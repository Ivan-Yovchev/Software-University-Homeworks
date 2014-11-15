using System;

class Rectangles
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter width: ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter height: ");
        double height = double.Parse(Console.ReadLine());

        double Perimiter = (2 * width) + (2 * height);
        double Area = height * width;

        Console.WriteLine("Perimiter: " + Perimiter);
        Console.WriteLine("Area: " + Area);
    }
}


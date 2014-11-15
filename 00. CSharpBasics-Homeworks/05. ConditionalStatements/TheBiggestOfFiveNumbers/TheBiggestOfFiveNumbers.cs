using System;

class TheBiggestOfFiveNumbers
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());
        Console.Write("Enter d: ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("Enter e: ");
        double e = double.Parse(Console.ReadLine());

        double max = a;

        if(b > max)
        {
            max = b;
        }
        if(c > max)
        {
            max = c;
        }
        if(d > max)
        {
            max = d;
        }
        if(e > max)
        {
            max = e;
        }

        Console.WriteLine("Biggest: " + max);
    }
}


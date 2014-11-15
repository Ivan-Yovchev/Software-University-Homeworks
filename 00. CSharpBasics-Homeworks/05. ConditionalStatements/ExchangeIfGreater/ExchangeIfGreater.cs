using System;

class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());

        if (a > b)
        {
            Console.WriteLine("Result: {0} {1}",b,a);
        }
        else
        {
            Console.WriteLine("Result: {0} {1}",a,b);
        }
    }
}


using System;

class TheBiggestOf3Numbers
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

        if(a >= b)
        {
            if(a >= c)
            {
                Console.WriteLine("Biggest: "+a);
            }
            else if(a < c)
            {
                Console.WriteLine("Biggest: " + c);
            }
        }
        else if(a < b)
        {
            if(b >= c)
            {
                Console.WriteLine("Biggest: " + b);
            }
            else if(b < c)
            {
                Console.WriteLine("Biggest: " + c);
            }
        }
    }
}


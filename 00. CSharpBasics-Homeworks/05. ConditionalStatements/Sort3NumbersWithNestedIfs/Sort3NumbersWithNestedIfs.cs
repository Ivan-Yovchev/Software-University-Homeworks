using System;

class Sort3NumbersWithNestedIfs
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
                if (b >= c)
                {
                    Console.WriteLine("Result: {0} {1} {2}", a, b, c);
                }
                else if(b < c)
                {
                    Console.WriteLine("Result: {0} {1} {2}", a, c, b);
                }
            }
            else if(a < c)
            {
                Console.WriteLine("Result: {0} {1} {2}", c, a, b);
            }
        }
        else if(a < b)
        {
            if(b >= c)
            {
                if(a >= c)
                {
                    Console.WriteLine("Result: {0} {1} {2}", b, a, c);
                }
                else if(a < c)
                {
                    Console.WriteLine("Result: {0} {1} {2}", b, c, a);
                }
            }
            else if( b < c)
            {
                Console.WriteLine("Result: {0} {1} {2}", c, b, a);
            }
        }
    }
}


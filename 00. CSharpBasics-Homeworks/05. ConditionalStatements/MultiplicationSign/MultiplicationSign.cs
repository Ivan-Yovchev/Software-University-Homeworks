using System;
class MultiplicationSign
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

        if(a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            // if the first number is a +
            if(a > 0)
            {
                if(b > 0)
                {
                    if (c > 0)
                    {
                        Console.WriteLine("Result: +");
                    }
                    else if (c < 0)
                    {
                        Console.WriteLine("Result: -");
                    }
                }
                else if(b < 0)
                {
                    if (c > 0)
                    {
                        Console.WriteLine("Result: -");
                    }
                    else if (c < 0)
                    {
                        Console.WriteLine("Result: +");
                    }
                }
            }

             // if the first number is a -
            else if( a < 0)
            {
                if (b > 0)
                {
                    if (c > 0)
                    {
                        Console.WriteLine("Result: -");
                    }
                    else if (c < 0)
                    {
                        Console.WriteLine("Result: +");
                    }
                }
                else if (b < 0)
                {
                    if (c > 0)
                    {
                        Console.WriteLine("Result: +");
                    }
                    else if (c < 0)
                    {
                        Console.WriteLine("Result: -");
                    }
                }
            }
        }
    }
}


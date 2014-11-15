using System;

class FormattingNumbers
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        //input
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());

        // convert a to hexadecimal
        string hex = a.ToString("X");
        // a to binary
        string binary = Convert.ToString(a, 2).PadLeft(10,'0');

        // output
        Console.Write("|{0,-10}",hex);
        Console.Write("|{0}",binary);
        // check if b is a double
        if (b == (int)b)
        {
            Console.Write("|{0,10}", b);
        }
        else 
        {
            Console.Write("|{0,10:F2}", b);
        }
        
        //check if c is a double
        if (c == (int)c)
        {
            Console.Write("|{0,-10}|", c);
        }
        else
        {
            Console.Write("|{0,-10:F3}|", c);
        }
        Console.WriteLine();
    }
}


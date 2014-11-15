using System;

class ComparingFloats
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        const double eps = 0.000001;
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        bool equal = false;

        double diff = a - b;
        if(diff < 0)
        {
            diff = 0 - diff;
        }

        if(diff<eps)
        {
            equal = true;
        }

        Console.WriteLine(equal);
    }
}


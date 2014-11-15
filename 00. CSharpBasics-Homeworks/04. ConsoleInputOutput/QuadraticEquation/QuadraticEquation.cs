using System;

class QuadraticEquation
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        // input
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());

        // calculate D
        double D = (b * b) - (4 * a * c);

        // the equation has two roots
        if(D > 0)
        {
            double x1 = (-b + (Math.Sqrt(D))) / (2*a);
            double x2 = (-b - (Math.Sqrt(D))) / (2*a);

            Console.WriteLine("x1 = {0}   x2 = {1}",x2, x1);
        }
        // the equation has one root
        else if(D == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("x1 = x2 = {0}",x);
        }
        //the equation has no roots
        else if(D < 0)
        {
            Console.WriteLine("no real roots");
        }
    }
}


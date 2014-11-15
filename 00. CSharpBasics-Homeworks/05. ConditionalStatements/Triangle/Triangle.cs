using System;

class Triangle
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        // point A
        int Ax = int.Parse(Console.ReadLine());
        int Ay = int.Parse(Console.ReadLine());

        //point B
        int Bx = int.Parse(Console.ReadLine());
        int By = int.Parse(Console.ReadLine());

        //point C
        int Cx = int.Parse(Console.ReadLine());
        int Cy = int.Parse(Console.ReadLine());

        // calculate length of each side
        double a = Math.Sqrt((Cx - Ax) * (Cx - Ax) + (Cy - Ay) * (Cy - Ay));
        double b = Math.Sqrt((Bx - Ax) * (Bx - Ax) + (By - Ay) * (By - Ay));
        double c = Math.Sqrt((Cx - Bx) * (Cx - Bx) + (Cy - By) * (Cy - By));

        // check if the figure is a triangle
        if ((a + b) > c && (b + c) > a && (a + c) > b)
        {
            Console.WriteLine("Yes");

            // calculate half of the perimiter
            double p = (a + b + c) / 2.0;

            // calculate the surface
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("{0:F2}",S);

        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}",b);
        }
    }
}


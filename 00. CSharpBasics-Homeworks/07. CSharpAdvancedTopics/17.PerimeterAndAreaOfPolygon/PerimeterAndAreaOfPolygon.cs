using System;
using System.Collections.Generic;

class PerimeterAndAreaOfPolygon
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        int n = int.Parse(Console.ReadLine());
        Polygon Polind = new Polygon();
        Polind.Coordinates = new List<Point>();

        for (int i = 0; i < n; i++)
        {
            string cordinate = Console.ReadLine();
            string[] numbers = cordinate.Split(' ');

            int x = int.Parse(numbers[0]);
            int y = int.Parse(numbers[1]);


            // create the two new point and save them
            Point point = new Point() { X = x, Y = y };

            //add points to list
            Polind.Coordinates.Add(point);
            Console.WriteLine();

        }
        Polind.Coordinates.Add(Polind.Coordinates[0]);

        CalculatePerimiter(Polind, n);

        CalculateArea(Polind, n);
    }

    private static void CalculatePerimiter(Polygon Pol, int lenght)
    {
        double Sum = 0;
        double d1 = 0;
        double d2 = 0;

        for (int i = 0; i < lenght; i++)
        {
            // calculate one side from the X coordinate
            if (Pol.Coordinates[i].X > Pol.Coordinates[i + 1].X)
            {
                d1 = Pol.Coordinates[i].X - Pol.Coordinates[i + 1].X;
            }
            else
            {
                d1 = Pol.Coordinates[i + 1].X - Pol.Coordinates[i].X;
            }

            //calculate other side from Y coordinate
            if (Pol.Coordinates[i].Y > Pol.Coordinates[i + 1].Y)
            {
                d2 = Pol.Coordinates[i].Y - Pol.Coordinates[i + 1].Y;
            }
            else
            {
                d2 = Pol.Coordinates[i + 1].Y - Pol.Coordinates[i].Y;
            }

            //calculate the lenght of the side
            double Side = Math.Sqrt((d1 * d1) + (d2 * d2));
            Sum += Side;
        }

        Console.WriteLine("Perimeter: {0:N2}", Sum);
    }

    private static void CalculateArea(Polygon Pol, int lenght)
    {
        int Sum = 0;
        for (int i = 0; i < lenght; i++)
        {
            // calculate by formula
            int TheX = Pol.Coordinates[i].X * Pol.Coordinates[i + 1].Y;
            int TheY = Pol.Coordinates[i].Y * Pol.Coordinates[i + 1].X;

            Sum += TheX - TheY;
        }

        double Area = Math.Abs((Sum / 2.0));

        Console.WriteLine("Area: {0:N2}", Area);

    }
}


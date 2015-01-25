using System;

class CalcDistance
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Point3D point1 = new Point3D(-7, -4, 3);
        Point3D point2 = new Point3D(17, 6, 2.5);

        double distance = DistanceCalculator.calcDistance(point1, point2);
        Console.WriteLine(distance);

    }
}

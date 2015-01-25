using System;

class MainProgram
{
    static void Main(string[] args)
    {
        Point3D point = new Point3D(1, 2, 3);
        Console.WriteLine(point);

        Console.WriteLine(Point3D.StartingPoint);
    }
}

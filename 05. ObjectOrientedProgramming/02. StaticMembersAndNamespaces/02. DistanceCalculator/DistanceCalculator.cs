
using System;
static class DistanceCalculator
{
    public static double calcDistance(Point3D point1, Point3D point2)
    {
        double distance = (point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y) + (point2.Z - point1.Z) * (point2.Z - point1.Z);
        distance = Math.Sqrt(distance);

        return distance;
    }
}

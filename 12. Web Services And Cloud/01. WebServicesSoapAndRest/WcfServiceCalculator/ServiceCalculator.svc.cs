using System;

namespace WcfServiceCalculator
{
    public class Calculator : ICalculator
    {
        public double CalcDistance(Point startPoint, Point endPoint)
        {
            var deltaX = startPoint.X - endPoint.X;
            var deltaY = startPoint.Y - endPoint.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}

using System;

class Triangle : BasicShape
{
    public Triangle(double width, double height)
        : base(width, height)
    {
    }
    public override double CalculateArea()
    {
        double area = (base.Width * base.Height) / 2;

        return area;
    }

    public override double CalcualtePerimiter()
    {
        double sideA = base.Width;
        double sideB = Math.Sqrt((base.Height * base.Height) + ((sideA / 2) * (sideA / 2)));

        return sideA + 2 * sideB;
    }

    public override string ToString()
    {
        return string.Format("Width: {0:N2}, Height: {1:N2}, Area: {2:N2}, Perimiter: {3:N2}",
            base.Width, base.Height, this.CalculateArea(), this.CalcualtePerimiter());
    }

}

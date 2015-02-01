using System;

class Rectangle : BasicShape
{
    public Rectangle(double width, double height)
        : base(width, height)
    {
    }

    public override double CalculateArea()
    {
        return base.Height * base.Width;
    }

    public override double CalcualtePerimiter()
    {
        return 2 * base.Width + 2 * base.Height;
    }

    public override string ToString()
    {
        return string.Format("Width: {0:N2}, Height: {1:N2}, Area: {2:N2}, Perimiter: {3:N2}",
            base.Width, base.Height, this.CalculateArea(), this.CalcualtePerimiter());
    }

}

using System;

class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get { return this.radius; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Radius cannot be zero or negative");
            }
            this.radius = value;
        }
    }

    public double CalculateArea()
    {
        return Math.PI * this.radius * this.radius;
    }

    public double CalcualtePerimiter()
    {
        return 2 * Math.PI * this.radius;
    }

    public override string ToString()
    {
        return string.Format("Radius: {0:N2}, Area: {1:N2}, Perimiter: {2:N2}",
            this.Radius, this.CalculateArea(), this.CalcualtePerimiter());
    }

}

using System;

public abstract class BasicShape : IShape
{

    private double width, height;

    public BasicShape(double width, double height)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative");
            }
            this.height = value;
        }
    }

    public abstract double CalculateArea();

    public abstract double CalcualtePerimiter();
}
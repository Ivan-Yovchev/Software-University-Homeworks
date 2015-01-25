public class Point3D
{
    private double x;
    private double y;
    private double z;
    private static Point3D startPoint = new Point3D(0, 0, 0);

    public Point3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public double X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    public double Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    public double Z
    {
        get { return this.z; }
        set { this.z = value; }
    }

    public static Point3D StartingPoint
    {
        get { return Point3D.startPoint; }
    }

    public override string ToString()
    {
        return "X: " + this.x + ", Y: " + this.y + " , Z: " + this.z;
    }

}
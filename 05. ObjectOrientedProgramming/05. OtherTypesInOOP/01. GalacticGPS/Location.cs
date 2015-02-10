using System;

struct Location
{
    public Location(double latitude, double longtitude, Planet planet)
        : this()
    {
        this.Latitude = latitude;
        this.Longtitude = longtitude;
        this.Planet = planet;
    }

    public double Latitude { get; set; }
    public double Longtitude { get; set; }
    public Planet Planet { get; set; }

    public override string ToString()
    {
        return string.Format("{0}, {1} - {2}", this.Latitude, this.Longtitude, this.Planet);
    }
}

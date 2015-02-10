using System;

class GalacticGPS
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Location home = new Location(18.037986, 28.870097, Planet.Earth);
        Console.WriteLine(home);
    }
}

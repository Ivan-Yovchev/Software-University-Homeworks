using System;

class GravitationOnTheMoon
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter weight: ");
        double EarthWeight = double.Parse(Console.ReadLine());

        double MoonWeight = (EarthWeight * 17) / 100;

        Console.WriteLine("Weight on the Moon: " + MoonWeight);
    }
}


using System;

class TestCalculator
{
    public const int n = 12;

    public static decimal GetSimpleInterest(decimal sum, double interest, int years)
    {
        return sum * (1 + (decimal)interest * years / 100);
    }

    public static decimal GetCompoundInterest(decimal sum, double interest, int years)
    {
        double power = Math.Pow(1 + (interest / n / 100), years * n);

        return sum * (decimal)power;
    }

    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        var simpleInterest = new InterestCalculator(2500m, 7.2, 15, GetSimpleInterest);
        Console.WriteLine(simpleInterest);

        var compoundInterest = new InterestCalculator(500m, 5.6, 10, GetCompoundInterest);
        Console.WriteLine(compoundInterest);
    }
}

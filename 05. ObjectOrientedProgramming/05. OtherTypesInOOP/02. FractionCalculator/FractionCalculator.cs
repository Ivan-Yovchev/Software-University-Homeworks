using System;

class FractionCalculator
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Fraction fraction1 = new Fraction(22, 7);
        Fraction fraction2 = new Fraction(40, 4);
        Fraction result = fraction1 + fraction2;
        Console.WriteLine(result.Numerator);
        Console.WriteLine(result.Denominator);
        Console.WriteLine(result);

    }
}

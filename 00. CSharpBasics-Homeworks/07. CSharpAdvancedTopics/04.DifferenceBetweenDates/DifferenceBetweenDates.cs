using System;
class DifferenceBetweenDates
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("bg-BG");

        Console.Write("Enter first date: ");
        DateTime First = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter second date: ");
        DateTime Second = DateTime.Parse(Console.ReadLine());

        TimeSpan Difference = Second - First;

        Console.WriteLine("Days between the two dates: " + Difference.Days);
    }
}


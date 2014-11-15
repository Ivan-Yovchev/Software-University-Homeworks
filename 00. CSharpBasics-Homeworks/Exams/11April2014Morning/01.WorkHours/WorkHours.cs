using System;

class WorkHours
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        int hoursToComplete = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int productivity = int.Parse(Console.ReadLine());

        double Biking = days / 10.0;
        double workHours = (days - Biking) * 12;
        double productiveHours = (workHours * productivity) / 100;

        if(hoursToComplete - (int)productiveHours > 0)
        {
            Console.WriteLine("No");
            Console.WriteLine(-(hoursToComplete - (int)productiveHours));
        }
        else if(hoursToComplete - (int)productiveHours <= 0)
        {
            Console.WriteLine("Yes");
            Console.WriteLine(-(hoursToComplete - (int)productiveHours));
        }
    }
}

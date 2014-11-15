using System;

class Cinema
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        string ticketType = Console.ReadLine();
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        double ticket = 0;

        if(ticketType == "Premiere")
        {
            ticket = 12.00;
        }
        else if(ticketType == "Normal")
        {
            ticket = 7.50;
        }
        else if(ticketType == "Discount")
        {
            ticket = 5.00;
        }

        int people = rows * cols;

        double income = ticket * people;

        Console.WriteLine("{0:F2} leva",income);
    }
}


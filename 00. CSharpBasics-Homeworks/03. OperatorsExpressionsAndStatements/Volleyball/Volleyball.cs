using System;

class Volleyball
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine();
        int hollydays = int.Parse(Console.ReadLine()); ;
        int hometown = int.Parse(Console.ReadLine()); ;

        double sum = 0;
        const int weeks = 48;

        sum += hometown;
        sum += ((weeks - hometown) * 3) / 4.0;
        sum += (hollydays * 2) / 3.0;

        if(year == "leap")
        {
            sum += (sum * 15) / 100;
        }
        Console.WriteLine((int)sum);
    }
}


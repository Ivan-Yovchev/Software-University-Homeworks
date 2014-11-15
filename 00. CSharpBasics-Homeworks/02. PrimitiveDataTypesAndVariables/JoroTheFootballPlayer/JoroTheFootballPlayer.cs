using System;

class JoroTheFootballPlayer
{
    static void Main(string[] args)
    {
        const int Weeks = 52;

        char LeapYear = char.Parse(Console.ReadLine());
        int Holidays = int.Parse(Console.ReadLine()); 
        int Hometown = int.Parse(Console.ReadLine()); 

        double Plays = 0;

        Plays += Hometown;
        Plays += ((Weeks - Hometown) * 2) / 3;
        Plays += Holidays / 2;

        if(LeapYear == 't')
        {
            Plays += 3;
        }

        Console.WriteLine(Plays);
    }
}


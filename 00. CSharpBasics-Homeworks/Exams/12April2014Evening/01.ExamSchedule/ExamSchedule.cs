using System;

class ExamSchedule
{
    static void Main(string[] args)
    {
        int StartHour = int.Parse(Console.ReadLine());
        int StartMinutes = int.Parse(Console.ReadLine());
        string TimeOfDay = Console.ReadLine();

        int DurationHours = int.Parse(Console.ReadLine());
        int DurationMinutes = int.Parse(Console.ReadLine());

        // calculate minutes
        int FinalMinutes = StartMinutes + DurationMinutes;
        if (FinalMinutes >= 60)
        {
            if (FinalMinutes == 60)
            {
                StartHour += 1;
                FinalMinutes = 00;
            }
            else if (FinalMinutes > 60)
            {
                StartHour += 1;
                FinalMinutes = FinalMinutes - 60;
            }
        }

        //calculate hour
        int FinalHour = StartHour + DurationHours;
        if (FinalHour > 12)
        {
            int TempHour = FinalHour - 12;
            if (TempHour < 12)
            {
                FinalHour = TempHour;

                if (TimeOfDay == "PM")
                {
                    TimeOfDay = "AM";
                }
                else
                {
                    TimeOfDay = "PM";
                }
            }
            else if (TempHour > 12)
            {
                FinalHour = TempHour - 12;
            }
        }
        else if (FinalHour == 12)
        {
            if (TimeOfDay == "PM")
            {
                TimeOfDay = "AM";
            }
            else
            {
                TimeOfDay = "PM";
            }
        }

        string hour = FinalHour.ToString();
        if (hour.Length < 2)
        {
            hour = hour.PadLeft(2, '0');
        }

        string minutes = FinalMinutes.ToString();
        if (minutes.Length < 2)
        {
            minutes = minutes.PadLeft(2, '0');
        }

        Console.Write(hour + ":");
        Console.Write(minutes + ":");
        Console.WriteLine(TimeOfDay);
    }
}

using System;

class MagicDates
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int weight = int.Parse(Console.ReadLine());

        bool output = false;
        DateTime start = new DateTime(startYear, 1, 1);
        DateTime end = new DateTime(endYear, 12, 31);

        while (true)
        {
            if (start == end.AddDays(1))
            {
                break;
            }

            string date = start.ToString("ddMMyyyy");
            char[] symbols = date.ToCharArray();
            int[] numbers = new int[symbols.Length];

            // get the numbers
            for (int i = 0; i < symbols.Length; i++)
            {
                switch (symbols[i])
                {
                    case '1': numbers[i] = 1; break;
                    case '2': numbers[i] = 2; break;
                    case '3': numbers[i] = 3; break;
                    case '4': numbers[i] = 4; break;
                    case '5': numbers[i] = 5; break;
                    case '6': numbers[i] = 6; break;
                    case '7': numbers[i] = 7; break;
                    case '8': numbers[i] = 8; break;
                    case '9': numbers[i] = 9; break;
                    case '0': numbers[i] = 0; break;
                }
            }

            //calculate sum
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    sum += numbers[i] * numbers[j];
                }
            }

            // if sum is equal to the wieght print date
            if (sum == weight)
            {
                Console.WriteLine(start.ToString("dd-MM-yyyy"));
                output = true;
            }

            start = start.AddDays(1);
        }

        if (output == false)
        {
            Console.WriteLine("No");
        }
    }
}

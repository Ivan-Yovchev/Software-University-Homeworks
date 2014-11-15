using System;

class MinMaxSumAndAverage
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        double n = double.Parse(Console.ReadLine());

        int min, max, sum;
        double avg;

        min = max = sum = int.Parse(Console.ReadLine());

        for (int i = 0; i < (int)n - 1; i++)
        {
            int temp = int.Parse(Console.ReadLine());

            if(temp > max)
            {
                max = temp;
            }
            else if(temp < min)
            {
                min = temp;
            }

            sum += temp;
        }

        avg = sum / n;

        Console.WriteLine("min = {0}",min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0:F2}", avg);
    }
}


using System;
using System.Collections.Generic;

class AverageLoadTimeCalculator
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        string line = Console.ReadLine();
        
        Dictionary<string, double> sum = new Dictionary<string, double>();
        Dictionary<string, int> count = new Dictionary<string, int>();
        Dictionary<string, double> loads = new Dictionary<string, double>();

        while(line != string.Empty)
        {
            string[] input = line.Split(' ');
            if(sum.ContainsKey(input[2]))
            {
                sum[input[2]] += double.Parse(input[3]);
                count[input[2]] += 1;
            }
            else
            {
                sum.Add(input[2], double.Parse(input[3]));
                count.Add(input[2], 1);
                loads.Add(input[2],0);
            }
            line = Console.ReadLine();
        }


        foreach (var site in sum.Keys)
        {
            loads[site] = sum[site] / count[site];
            Console.WriteLine("{0} -> {1}",site,loads[site]);
        }

    }
}


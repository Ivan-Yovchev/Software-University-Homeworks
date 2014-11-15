using System;
using System.Collections.Generic;

class LongestAreaInArray
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number n: ");
        int n = int.Parse(Console.ReadLine());

        string[] elements = new string[n];

        Console.WriteLine("Enter {0} strings: ",n);
        for (int i = 0; i < n; i++)
        {
            elements[i] = Console.ReadLine();
        }

        var count = new Dictionary<string, int>();
        foreach (string value in elements)
        {
            if (count.ContainsKey(value))
            {
                count[value]++;
            }
            else
            {
                count.Add(value, 1);
            }
        }

        string mostCommonString = String.Empty;
        int highestCount = 0;
        foreach (var pair in count)
        {
            if (pair.Value > highestCount)
            {
                mostCommonString = pair.Key;
                highestCount = pair.Value;
            }
        }

        // output
        Console.WriteLine("Length of most common string: ");
        Console.WriteLine(highestCount);
        for (int i = 0; i < highestCount; i++)
        {
            Console.WriteLine(mostCommonString);
        }
    }
}


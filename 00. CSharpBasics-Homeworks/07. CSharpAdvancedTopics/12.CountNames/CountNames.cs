using System;
using System.Collections.Generic;
using System.Linq;

class CountNames
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        Array.Sort(input);

        Dictionary<string, int> names = new Dictionary<string, int>();
        for (int i = 0; i < input.Length; i++)
        {
            if (names.ContainsKey(input[i]))
            {
                names[input[i]]++;
            }
            else
            {
                names.Add(input[i], 1);
            }
        }

        foreach (var name in names)
        {
            Console.WriteLine("{0} -> {1}", name.Key, name.Value);
        }
    }
}


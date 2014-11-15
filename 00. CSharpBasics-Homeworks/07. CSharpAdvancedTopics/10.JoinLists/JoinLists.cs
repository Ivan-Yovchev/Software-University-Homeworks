using System;
using System.Collections.Generic;
using System.Linq;

class JoinLists
{
    static void Main(string[] args)
    {
        var First = new List<int>();
        Console.Write("Enter first list: ");
        string[] temp = Console.ReadLine().Split(' ');
        for (int i = 0; i < temp.Length; i++)
        {
            First.Add(Convert.ToInt32(temp[i]));
        }

        var Second = new List<int>();
        Console.Write("Enter second list: ");
        temp = Console.ReadLine().Split(' ');
        for (int i = 0; i < temp.Length; i++)
        {
            Second.Add(Convert.ToInt32(temp[i]));
        }

        // join and remove repeating numbers
        var all = First.Concat(Second).Distinct().ToList();
        all.Sort();

        Console.Write("Joined lists: ");
        foreach (var num in all)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

    }
}


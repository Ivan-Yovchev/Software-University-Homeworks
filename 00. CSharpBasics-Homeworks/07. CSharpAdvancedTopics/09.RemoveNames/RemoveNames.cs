using System;
using System.Collections.Generic;

class RemoveNames
{
    static void Main(string[] args)
    {
        var allNames = new List<string>();
        Console.Write("Enter first list: ");
        string[] temp = Console.ReadLine().Split(' ');
        for (int i = 0; i < temp.Length; i++)
        {
            allNames.Add(temp[i]);
        }

        var toRemoveNames = new List<string>();
        Console.Write("Enter second list: ");
        temp = Console.ReadLine().Split(' ');
        for (int i = 0; i < temp.Length; i++)
        {
            toRemoveNames.Add(temp[i]);
        }

        var removedNames = new List<int>();
        for (int i = 0; i < toRemoveNames.Count; i++)
        {
            for (int j = 0; j < allNames.Count; j++)
            {
                if(toRemoveNames[i] == allNames[j])
                {
                    removedNames.Add(j);
                }
            }
        }

        Console.Write("List with removed names: ");
        int removed = 0;
        for (int i = 0; i < removedNames.Count; i++)
        {
            allNames.Remove(allNames[removedNames[i] - removed]);
            removed++;
        }

        foreach (var name in allNames)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }
}


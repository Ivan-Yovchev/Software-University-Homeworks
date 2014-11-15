using System;
using System.Collections.Generic;

class CountOfLetters
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        Array.Sort(input);

        Dictionary<string, int> letters = new Dictionary<string, int>();
        for (int i = 0; i < input.Length; i++)
        {
            if(letters.ContainsKey(input[i]))
            {
                letters[input[i]]++;
            }
            else
            {
                letters.Add(input[i], 1);
            }
        }

        foreach (var letter in letters)
        {
            Console.WriteLine("{0} -> {1}",letter.Key,letter.Value);
        }
    }
}


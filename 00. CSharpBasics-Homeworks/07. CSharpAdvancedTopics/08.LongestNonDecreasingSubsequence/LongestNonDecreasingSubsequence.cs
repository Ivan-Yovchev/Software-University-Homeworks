using System;
using System.Collections.Generic;
using System.Linq;

class LongestNonDecreasingSubsequence
{
    static void Main(string[] args)
    {
        // I think the team had given wrong output for this problem
        // the program outputs what I considered right

        string[] inputLine = Console.ReadLine().Split(' ');

        int count = (int)Math.Pow(2, inputLine.Length);

        List<int> LongestSequence = new List<int>();

        for (int i = 1; i < count; i++)
        {
            string mask = Convert.ToString(i, 2).PadLeft(inputLine.Length, '0');
            List<int> sequence = new List<int>();
            bool nonDecreasing = true;

            for (int j = 0; j < mask.Length; j++)
            {
                if(mask[j] == '1')
                {
                    sequence.Add(Convert.ToInt32(inputLine[j]));
                }
            }

            int value = Int32.MinValue;
            for (int j = 0; j < sequence.Count; j++)
            {
                if(value <= sequence[j])
                {
                    value = sequence[j];
                }
                else if(value > sequence[j])
                {
                    nonDecreasing = false;
                    break;
                }
            }

            if(sequence.Count > LongestSequence.Count && nonDecreasing == true)
            {
                LongestSequence = sequence;
            }

        }

        foreach (var num in LongestSequence)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}


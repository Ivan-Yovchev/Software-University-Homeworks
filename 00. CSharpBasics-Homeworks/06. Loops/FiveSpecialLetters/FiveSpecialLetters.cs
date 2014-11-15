using System;
using System.Collections.Generic;

class FiveSpecialLetters
{
    static void Main(string[] args)
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e' };
        bool output = false;

        for (int a = 0; a < 5; a++)
        {
            for (int b = 0; b < 5; b++)
            {
                for (int c = 0; c < 5; c++)
                {
                    for (int d = 0; d < 5; d++)
                    {
                        for (int e = 0; e < 5; e++)
                        {
                            string sequence = "" + letters[a] + letters[b] + letters[c] + letters[d] + letters[e];
                            string removedLetters = RemoveRepeatingLetters(sequence);
                            int weight = CalculateWeight(removedLetters);

                            if (weight >= start && weight <= end)
                            {
                                Console.Write(sequence + " ");
                                output = true;
                            }
                        }
                    }
                }
            }
        }

        if(output == false)
        {
            Console.WriteLine("No");
        }

    }

    private static int CalculateWeight(string x)
    {
        int result = 0;
        for (int i = 0; i < x.Length; i++)
        {
            switch(x[i])
            {
                case 'a': result += (i + 1) * 5; break;
                case 'b': result += (i + 1) * -12; break;
                case 'c': result += (i + 1) * 47; break;
                case 'd': result += (i + 1) * 7; break;
                case 'e': result += (i + 1) * -32; break;
            }
        }

        return result;
    }

    private static string RemoveRepeatingLetters(string x)
    {
        char[] letters = x.ToCharArray();
        string result = "";
        for (int i = 0; i < letters.Length; i++)
        {
            for (int j = i + 1; j < letters.Length; j++)
            {
                if(letters[i] == letters[j])
                {
                    letters[j] = 'X';
                }
            }
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if(letters[i] != 'X')
            {
                result += letters[i];
            }
        }

        return result;
    }
}


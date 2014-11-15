using System;
using System.Collections.Generic;

class SequenceOfKNumbers
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');
        int k = int.Parse(Console.ReadLine());

        if(k == 1)
        {
            Console.WriteLine();
        }
        else
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int temp = Convert.ToInt32(input[i]);
                numbers.Add(temp);
            }

            int number = numbers[0];
            int count = 1;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == number)
                {
                    count++;

                    if (count == k)
                    {
                        for (int j = i; j >= i - count + 1; j--)
                        {
                            numbers[j] = Int32.MinValue;
                        }

                        if (i + 1 != numbers.Count)
                        {
                            if (number == numbers[i + 1])
                            {
                                count = 0;
                            }
                        }
                    }
                }
                else if (numbers[i] != number)
                {
                    number = numbers[i];
                    count = 1;
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != Int32.MinValue)
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}


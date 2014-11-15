using System;
using System.Collections.Generic;

class BiggestTriple
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');

        List<int> numbers = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            int temp = int.Parse(input[i]);
            numbers.Add(temp);
        }

        if (numbers.Count % 3 != 0)
        {
            while (numbers.Count % 3 != 0)
            {
                numbers.Add(0);
            }
        }

        //foreach (var num in numbers)
        //{
        //    Console.WriteLine(num);
        //}

        int Sum = Int32.MinValue;
        List<int> output = new List<int>();

        for (int i = 0; i < numbers.Count; i += 3)
        {
            int tempSum = numbers[i] + numbers[i + 1] + numbers[i + 2];

            if (tempSum > Sum)
            {
                Sum = tempSum;
                List<int> tempNumbers = new List<int>();

                if (i >= (input.Length - (input.Length % 3)))
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        if (numbers[j] != 0)
                        {
                            tempNumbers.Add(numbers[j]);
                        }
                    }

                    output = new List<int>(tempNumbers);
                }
                else
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        tempNumbers.Add(numbers[j]);
                    }

                    output = new List<int>(tempNumbers);
                }
            }
        }

        foreach (var num in output)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}

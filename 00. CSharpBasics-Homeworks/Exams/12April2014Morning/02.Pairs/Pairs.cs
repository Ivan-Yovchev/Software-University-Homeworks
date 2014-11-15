using System;

class Pairs
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split(' ');

        int[] numbers = new int[input.Length];
        int[] values = new int[(numbers.Length) / 2];
        bool equals = true;

        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        //calculate values
        int j = 0;
        for (int i = 0; i < numbers.Length; i += 2)
        {
            values[j] = numbers[i] + numbers[i + 1];
            j++;
        }

        // check if all values are the same
        int check = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            if (values[i] != check)
            {
                equals = false;
                break;
            }
        }

        //output
        if (equals == true)
        {
            Console.WriteLine("Yes, value={0}", values[0]);
        }
        else if (equals == false)
        {
            int maxDifference = 0;

            for (int i = 0; i < values.Length - 1; i++)
            {
                int diff = Math.Abs(values[i] - values[i + 1]);

                if (diff > maxDifference)
                {
                    maxDifference = diff;
                }
            }

            Console.WriteLine("No, maxdiff={0}", maxDifference);
        }

    }
}

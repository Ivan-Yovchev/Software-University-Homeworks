using System;

class RandomizeTheNumbers1ToN
{
    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        Random rand = new Random();

        // get the first value so the others can be compared to sth
        numbers[0] = rand.Next(1, n + 1);
        Console.Write(numbers[0] + " ");

        int index = 1;
        int count = 1;
        while (true)
        {
            if (count == n)
            {
                break;
            }

            int next = rand.Next(1, n + 1);
            bool repeat = false;

            // check for repeating values
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == next)
                {
                    repeat = true;
                    break;
                }
            }

            if (repeat == false)
            {
                numbers[index] = next;
                Console.Write(next + " ");
                index++;
                count++;
            }
        }

        Console.WriteLine();
    }
}


using System;

class SumOfElements
{
    static void Main(string[] args)
    {

        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }


        bool hasElement = false;
        int memory = Int32.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            int element = numbers[i];
            int sum = 0;

            for (int j = 0; j < numbers.Length; j++)
            {
                sum += numbers[j];
            }

            if(element == (sum - element) && element != memory)
            {
                hasElement = true;
                Console.WriteLine("Yes, sum=" + element);
                memory = element;
            }
        }

        if (hasElement == false)
        {
            int sum = 0, diff = Int32.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                int element = numbers[i];
                sum = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    sum += numbers[j];
                }

                sum -= element;

                if (element > sum)
                {
                    int difference = element - sum ;
                    if (difference < diff)
                    {
                        diff = difference;
                    }
                }
                else if (sum > element)
                {
                    int difference = sum - element;
                    if (difference < diff)
                    {
                        diff = difference;
                    }
                }

            }

            Console.WriteLine("No, diff=" + diff);
        }
    }
}


using System;
class ZeroSubset
{
    static void Main(string[] args)
    {
        int sum = 0;
        int n = 5;
        int[] numbers = new int[n];
       

        string[] input = Console.ReadLine().Split(' ');

        for (int i = 0; i < n; i++)
        {
            numbers[i] = Convert.ToInt32(input[i]);
        }

        int count = (int)Math.Pow(2, n);

        for (int i = 1; i < count; i++)
        {
            string mask = Convert.ToString(i, 2).PadLeft(n, '0');

            int combinationSum = 0;

            for (int j = 0; j < n; j++)
            {
                int charValue = Convert.ToInt32(char.GetNumericValue(mask[j]));

                combinationSum += charValue * numbers[j];
            }

            if(sum == combinationSum)
            {
                for (int j = 0; j < n; j++)
                {
                    int charValue = Convert.ToInt32(char.GetNumericValue(mask[j]));

                    if(charValue != 0)
                    {
                        Console.Write("{0} ", charValue * numbers[j]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}


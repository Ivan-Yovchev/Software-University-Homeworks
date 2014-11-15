using System;

class CalculateN_DividedByK_
{
    static void Main(string[] args)
    {
        // N!/K! is equal to
        // (K+1)*(K+2)*...*N 

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        int Result = 1;

        for (int i = k + 1; i <= n; i++)
        {
            Result *= i;
        }

        Console.WriteLine(Result);
    }
}


using System;
using System.Numerics;

class CalculateTheNumberOfCombinations
{
    static void Main(string[] args)
    {
        // N! / (K! * (N-K)!) equals to
        // ((K+1)*(K+2)*...*N) / (N-K)!

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());

        BigInteger Top = 1;

        for (int i = k + 1; i <= n; i++)
        {
            Top *= i;
        }

        BigInteger Bottom = 1;
        for (int i = 2; i <= (n-k); i++)
        {
            Bottom *= i;
        }

        BigInteger result = Top / Bottom;

        Console.WriteLine("Result: " + result);
    }
}


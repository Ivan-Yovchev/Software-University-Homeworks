using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int k = n + 1;

        BigInteger Top = 1;

        for (int i = k + 1; i <= 2*n; i++)
        {
            Top *= i;
        }

        BigInteger Bottom = 1;
        for (int i = 2; i <= n; i++)
        {
            Bottom *= i;
        }

        Console.WriteLine("Result: " + Top / Bottom);
    }
}


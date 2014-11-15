using System;

class TrailingZeroesInN
{
    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        int zeroes = 0, p = 5;
        while (n >= p)
        {
            zeroes += n / p;
            p *= 5;
        }

        Console.WriteLine("Number of zeros: " + zeroes);
    }
}


using System;

class PrimeChecker
{
    static void Main(string[] args)
    {
        Console.Write("Enter number: ");
        ulong n = ulong.Parse(Console.ReadLine());

        bool Prime = CheckPrime(n);

        Console.WriteLine("Is Prime: {0}",Prime);
    }

    private static bool CheckPrime(ulong x)
    {
        bool isPrime = true;

        if (x == 0 || x == 1)
        {
            isPrime = false;
            return isPrime;
        }
        else
        {
            for (ulong i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }

        return isPrime;
    }
}


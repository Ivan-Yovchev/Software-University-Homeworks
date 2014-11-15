using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main(string[] args)
    {
        Console.Write("Enter start number: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Enter end number: ");
        int end = int.Parse(Console.ReadLine());

        List<int> primes = new List<int>();

        // get primes
        for (int i = start; i <= end; i++)
        {
            //check for primes
            bool temp = CheckPrime(i);
            if(temp == true)
            {
                primes.Add(i);
            }
        }

        //output primes
        if(primes.Count == 0)
        {
            Console.WriteLine("(empty list)");
        }
        else
        {
            for (int i = 0; i < primes.Count; i++)
            {
                if (i != primes.Count - 1)
                {
                    Console.Write("{0}, ", primes[i]);
                }
                else
                {
                    Console.WriteLine("{0}", primes[i]);
                }


                if ((i + 1) % 12 == 0 && i != 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }

    private static bool CheckPrime(int x)
    {
        bool isPrime = true;

        if (x == 0 || x == 1)
        {
            isPrime = false;
            return isPrime;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(x); i++)
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


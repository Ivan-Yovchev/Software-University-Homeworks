using System;

class NumbersInIntervalDividableBy5
{
    static void Main(string[] args)
    {
        Console.Write("Enter start number: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Enter end number: ");
        int end = int.Parse(Console.ReadLine());

        int count = 0;

        for (int i = start; i <= end; i++)
        {
            if (i % 5 == 0)
            {
                count++;
            }
        }

        Console.WriteLine("p = {0}",count);
    }
}


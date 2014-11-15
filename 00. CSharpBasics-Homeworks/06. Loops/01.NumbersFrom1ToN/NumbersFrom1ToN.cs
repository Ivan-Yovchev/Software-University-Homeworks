using System;
class NumbersFrom1ToN
{
    static void Main(string[] args)
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}


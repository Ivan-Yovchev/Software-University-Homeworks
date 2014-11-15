using System;

class FibonacciNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        if(n == 1)
        {
            Console.Write(0 + " ");
            Console.WriteLine();
        }
        else if(n == 2)
        {
            Console.Write(0 + " ");
            Console.Write(1 + " ");
            Console.WriteLine();
        }
        else if(n == 3)
        {
            Console.Write(0 + " ");
            Console.Write(1 + " ");
            Console.Write(1 + " ");
            Console.WriteLine();
        }
        else
        {
            int a = 0, b = 1, c = 1;
            Console.Write(0 + " ");
            Console.Write(1 + " ");
            Console.Write(1 + " ");
            for (int i = 0; i < n - 3 ; i++)
            {
                a = b;
                b = c;
                c = a + b;
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }
    }
}


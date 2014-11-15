using System;

class FibonacciNumbers
{
    static void Main(string[] args)
    {
        Console.Write("Enter Fibonacci index n: ");
        int n = int.Parse(Console.ReadLine());

        if(n == 0)
        {
            Console.WriteLine("Fibonacci Number: " + 1);
        }
        else if(n == 1)
        {
            Console.WriteLine("Fibonacci Number: " + 1);
        }
        else if(n == 2)
        {
            Console.WriteLine("Fibonacci Number: " + 2);
        }
        else
        {
            int a = 1;
            int b = 1;
            int c = 2;

            for (int i = 0; i < n - 2; i++)
            {
                a = b;
                b = c;
                c = a + b;
            }
            // output
            Console.WriteLine("Fibonacci Number: {0}",c);
        }

    }
}


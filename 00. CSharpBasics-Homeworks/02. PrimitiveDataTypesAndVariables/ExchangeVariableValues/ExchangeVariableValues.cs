using System;

class ExchangeVariableValues
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("Before exchange");
        Console.WriteLine("a: {0}  b: {1}",a,b);
        Console.WriteLine();

        // exchanging integers
        int Temp = a;
        a = b;
        b = Temp;

        Console.WriteLine("After exchange");
        Console.WriteLine("a: {0}  b: {1}", a, b);
    }
}


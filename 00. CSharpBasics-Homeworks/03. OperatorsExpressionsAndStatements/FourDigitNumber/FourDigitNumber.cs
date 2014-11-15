using System;

class FourDigitNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());
        int a, b, c, d;

        a = (Num / 1000) % 10;
        b = (Num / 100) % 10;
        c = (Num / 10) % 10;
        d = Num % 10;

        Console.WriteLine("Sum: " + (a + b + c + d));
        Console.WriteLine("Reversed: " + d + c + b + a);
        Console.WriteLine("Last digit in front: " + d + a + b + c);
        Console.WriteLine("Second and third digits exchanged: " + a + c + b + d);
    }
}


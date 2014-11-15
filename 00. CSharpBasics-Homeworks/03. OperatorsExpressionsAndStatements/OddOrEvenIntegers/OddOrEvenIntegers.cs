using System;

class OddOrEvenIntegers
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());

        if (Num % 2 == 0 || Num == 0)
        {
            Console.WriteLine("false");
        }
        else if (Num % 2 != 0)
        {
            Console.WriteLine("true");
        }
    }
}


using System;

class ExtractBitFromInteger
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());
        Console.Write("Enter index: ");
        int index = int.Parse(Console.ReadLine());

        if ((Num & (int)Math.Pow(2, index)) != 0)
        {
            Console.WriteLine('1');
        }
        else
        {
            Console.WriteLine('0');
        }
    }
}


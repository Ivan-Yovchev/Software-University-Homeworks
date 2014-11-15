using System;

class CheckBitAtPosition
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());
        Console.Write("Enter index: ");
        int index = int.Parse(Console.ReadLine());
        bool ActiveBit = true;

        if ((Num & (int)Math.Pow(2, index)) != 0)
        {
            Console.WriteLine(ActiveBit);
        }
        else
        {
            ActiveBit = false;
            Console.WriteLine(ActiveBit);
        }
    }
}


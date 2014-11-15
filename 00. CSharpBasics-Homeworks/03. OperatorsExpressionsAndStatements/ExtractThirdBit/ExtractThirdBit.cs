using System;
class ExtractThirdBit
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());

        if((Num & (int)Math.Pow(2,3)) != 0)
        {
            Console.WriteLine('1');
        }
        else
        {
            Console.WriteLine('0');
        }
    }
}


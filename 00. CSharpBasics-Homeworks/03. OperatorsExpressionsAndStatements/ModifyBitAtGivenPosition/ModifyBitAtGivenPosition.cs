using System;

class ModifyBitAtGivenPosition
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());
        Console.Write("Enter index: ");
        int index = int.Parse(Console.ReadLine());
        Console.Write("Enter bit value: ");
        int Bitvalue = int.Parse(Console.ReadLine());

        if ((Num & (int)Math.Pow(2, index)) == Bitvalue)
        {
            Console.WriteLine(Num);
        }
        else if((Num & (int)Math.Pow(2, index)) !=0 & Bitvalue == 1)
        {
            Console.WriteLine(Num);
        }
        else if((Num & (int)Math.Pow(2, index)) !=0 & Bitvalue == 0)
        {
            Num = Num & (~(1 << index));
            Console.WriteLine(Num);
        }
        else if((Num & (int)Math.Pow(2, index)) == 0 & Bitvalue == 1)
        {
            Num = Num | (1 << index);
            Console.WriteLine(Num);
        }
    }
}


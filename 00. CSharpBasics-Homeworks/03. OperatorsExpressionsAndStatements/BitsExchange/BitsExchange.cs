using System;

class BitsExchange
{
    static void Main(string[] args)
    {   //n = n & (~(1 << p)); nula
        //n = n | (1 << p); edno
        Console.Write("Enter Integer: ");
        uint Num = uint.Parse(Console.ReadLine());

        for (int i = 3; i < 6; i++)
        {
            if((Num & (int)Math.Pow(2,i)) != 0 && (Num & (int)Math.Pow(2,i+21)) == 0)
            {
                Num = (uint)(Num & (~(1 << i)));
                Num = (uint)(Num | (1 << i + 21));
            }
            else if((Num & (int)Math.Pow(2,i)) == 0 && (Num & (int)Math.Pow(2,i+21)) != 0)
            {
                Num = (uint)(Num & (~(1 << i + 21)));
                Num =(uint)(Num | (1 << i));
            }
        }
        Console.WriteLine(Num);
    }
}


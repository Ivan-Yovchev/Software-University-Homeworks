using System;

class AdvancedBitExchange
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        uint Num = uint.Parse(Console.ReadLine());
        Console.Write("Enter p: ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter q: ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        if(p > q)
        {
            int temp = q;
            q = p;
            p = temp;
        }

        int Difference = q - p;

        if (p < 0 || q > 31 || q + k >=32)
        {
            Console.WriteLine("out of range");
        }
        else if(p + k>=q)
        {
            Console.WriteLine("overlapping");
        }
        else
        {
            for (int i = 0; i < k; i++)
            {
                if ((Num & (int)Math.Pow(2, p + i)) != 0 && (Num & (int)Math.Pow(2, q + i)) == 0)
                {
                    Num = (uint)(Num & (~(1 << p+i)));
                    Num = (uint)(Num | (1 << q + i));
                }
                else if ((Num & (int)Math.Pow(2, p+i)) == 0 && (Num & (int)Math.Pow(2, q + i)) != 0)
                {
                    Num = (uint)(Num & (~(1 << q + i)));
                    Num = (uint)(Num | (1 << p + i));
                }
            }
            Console.WriteLine(Num);
        }
    }
}


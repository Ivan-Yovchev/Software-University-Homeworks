using System;

class CatchTheBits
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        string binaryLine = "";
        string Numbers = "";

        for (int i = 0; i < n; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            string Num = Convert.ToString(temp, 2).PadLeft(8, '0');
            binaryLine += Num;
        }

        char[] OnesAndZeros = binaryLine.ToCharArray();

        for (int i = 1; i < OnesAndZeros.Length; i += step)
        {
            if (OnesAndZeros[i] == '1')
            {
                Numbers += "1";
            }
            else if (OnesAndZeros[i] == '0')
            {
                Numbers += "0";
            }
        }

        //Console.WriteLine(Numbers);

        if (Numbers.Length < 8)
        {
            Numbers = Numbers.PadRight(8, '0');
            int num = Convert.ToInt32(Numbers, 2);
            Console.WriteLine(num);
        }
        else
        {
            int length = Numbers.Length;
            if (length % 8 != 0)
            {
                while (length % 8 != 0)
                {
                    length++;
                }
            }
            //Console.WriteLine("le: "+length);
            Numbers = Numbers.PadRight(length, '0');

            for (int i = 0; i < Numbers.Length; i += 8)
            {
                string Temp = Numbers.Substring(i, 8);
                long num = Convert.ToInt64(Temp, 2);
                Console.WriteLine(num);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;

class BitFlipper
{
    static void Main(string[] args)
    {
         BigInteger num = BigInteger.Parse(Console.ReadLine());

        List<char> binary = new List<char>();
        while(num != 0)
        {
            if(num % 2 == 0)
            {
                binary.Add('0');
                num /= 2;
            }
            else if(num % 2 != 0)
            {
                binary.Add('1');
                num /= 2;
            }
        }

        if(binary.Count < 64)
        {
            while(binary.Count != 64)
            {
                binary.Insert(binary.Count, '0');
            }
        }

        for (int i = binary.Count - 1; i >= 0; i--)
        {
            if (i > 1)
            {
                if (binary[i] == binary[i - 1] && binary[i] == binary[i - 2])
                {
                    if (binary[i] == '0')
                    {
                        binary[i] = binary[i - 1] = binary[i - 2] = '1';
                    }
                    else if (binary[i] == '1')
                    {
                        binary[i] = binary[i - 1] = binary[i - 2] = '0';
                    }

                    i -= 2;
                }
            }
        }

        BigInteger number = 0;
        for (int i = 0; i < binary.Count; i++)
        {
            if (binary[i] == '1')
            {
                BigInteger temp = (BigInteger)Math.Pow(2, i);
                number += temp;
            }
        }

         Console.WriteLine(number);
    }
}


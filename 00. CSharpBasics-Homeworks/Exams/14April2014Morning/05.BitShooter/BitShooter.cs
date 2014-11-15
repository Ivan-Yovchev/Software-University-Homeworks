using System;
using System.Collections.Generic;

class BitShooter
{
    static void Main(string[] args)
    {
        ulong number = ulong.Parse(Console.ReadLine());

        List<char> bits = new List<char>();

        while (number != 0)
        {
            if (number % 2 == 0)
            {
                bits.Add('0');
            }
            else
            {
                bits.Add('1');
            }

            number /= 2;
        }

        while (bits.Count < 64)
        {
            bits.Add('0');
        }

        for (int i = 0; i < 3; i++)
        {
            string[] target = Console.ReadLine().Split(' ');
            int center = Convert.ToInt32(target[0]);
            int radius = (Convert.ToInt32(target[1])) / 2;

            if (bits[center] == '1')
            {
                bits[center] = '0';
            }

            for (int j = 0; j < radius; j++)
            {
                //blast radius left
                if (center != 0 && (center - 1 - j) > 0)
                {
                    if (bits[center - 1 - j] == '1')
                    {
                        bits[center - 1 - j] = '0';
                    }
                }

                //blast radius right
                if (center != bits.Count - 1 && (center + 1 + j) < bits.Count - 1)
                {
                    if (bits[center + 1 + j] == '1')
                    {
                        bits[center + 1 + j] = '0';
                    }
                }
            }

            //foreach (var bit in bits)
            //{
            //    Console.Write(bit);
            //}
            //Console.WriteLine();
            //Console.WriteLine();
        }

        //count zeros
        int right = 0, left = 0;
        for (int i = 0; i < bits.Count; i++)
        {
            if (i < bits.Count / 2 && bits[i] == '1')
            {
                right++;
            }
            else if (i >= bits.Count / 2 && bits[i] == '1')
            {
                left++;
            }
        }

        Console.WriteLine("left: {0}", left);
        Console.WriteLine("right: {0}", right);

    }
}

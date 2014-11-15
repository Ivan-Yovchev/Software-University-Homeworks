using System;

class BitSifting
{
    static void Main(string[] args)
    {
        //get the number that needs sifting
        ulong Num = ulong.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        //create arry to store bits
        int[,] bits = new int[n+2, 64];

        //write the numbers bits
        for (int i = 0; i < 64; i++)
        {
            if((Num & (ulong)Math.Pow(2,i)) != 0)
            {
                bits[0, i] = 1;
            }
        }

        //get the other numbers
        for (int i = 1; i <= n; i++)
        {
            ulong temp = ulong.Parse(Console.ReadLine());
            for (int j = 0; j < 64; j++)
            {
                if ((temp & (ulong)Math.Pow(2, j)) != 0)
                {
                    bits[i, j] = 1;
                }
            }
        }

        for (int i = 0; i < 64; i++)
        {
            if(bits[0,i]==1)
            {
                for (int j = 1; j < n+2; j++)
                {
                    if (bits[j, i] == 1)
                    {
                        break;
                    }
                    else if (j == n + 1)
                    {
                        bits[j, i] = 1;
                    }
                }
            }
        }


        //count
        int count = 0;
        for (int i = 0; i < 64; i++)
        {
            if(bits[n+1,i]==1)
            {
                count++;
            }
        }
        Console.WriteLine(count);

    }
}


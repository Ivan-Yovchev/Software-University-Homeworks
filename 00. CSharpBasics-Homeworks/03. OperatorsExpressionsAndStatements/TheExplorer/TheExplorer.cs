using System;

class TheExplorer
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        // top part
        for (int i = 0; i <= n/2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == n / 2)
                {
                    Console.Write('*');
                }
                else if (j == (n / 2) - i || j == (n / 2) + i)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('-');
                }
            }
            Console.WriteLine();
        }

        //lower part
        for (int i = (n/2)-2; i >= -1; i--)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == -1 && j == n / 2)
                {
                    Console.Write('*');
                }
                else if((n/2)-(j+i)==1 || (j-i)-(n/2)==1)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('-');
                }
            }
            Console.WriteLine();
        }
    }
}


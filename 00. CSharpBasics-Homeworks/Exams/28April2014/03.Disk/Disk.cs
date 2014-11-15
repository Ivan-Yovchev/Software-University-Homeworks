using System;

class Disk
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int radius = int.Parse(Console.ReadLine());
        int center = n/2;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if((i - center)*(i - center) + (j - center)*(j - center) <= radius*radius)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
        }
    }
}


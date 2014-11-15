using System;

class InsideTheBuilding
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int[] dots = new int[10];

        for (int i = 0; i < 10; i++)
        {
            int point = int.Parse(Console.ReadLine());
            dots[i] = point;
        }

        for (int i = 0; i < 10; i+=2)
        {
            int x = dots[i];
            int y = dots[i + 1];

            // look at the building as two seperate sections

            // first section
            if (y <= n && y >= 0 && x >= 0 && x <= 3 * n)
            {
                Console.WriteLine("inside");
            }
            //second section
            else if( y > n && y <= 4*n && x>=n && x<=2*n)
            {
                Console.WriteLine("inside");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}


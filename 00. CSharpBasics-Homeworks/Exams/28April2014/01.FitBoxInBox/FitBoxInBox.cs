using System;
class FitBoxInBox
{
    static void Main(string[] args)
    {
        //first one
        int w1 = int.Parse(Console.ReadLine());
        int h1 = int.Parse(Console.ReadLine());
        int d1 = int.Parse(Console.ReadLine());

        //second one
        int w2 = int.Parse(Console.ReadLine());
        int h2 = int.Parse(Console.ReadLine());
        int d2 = int.Parse(Console.ReadLine());

        //the second one will always be the bigger one

        if((w1 + h1 + d1) > (w2 + h2 + d2))
        {
            //change w
            int temp = w2;
            w2 = w1;
            w1 = temp;

            //change h
            temp = h2;
            h2 = h1;
            h1 = temp;

            //change d
            temp = d2;
            d2 = d1;
            d1 = temp;
        }

        //logic
        for (int i = 0; i < 6; i++)
        {
            if(w1 < w2 && h1 < h2 && d1 < d2)
            {
                Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})",w1,h1,d1,w2,h2,d2);
            }

            if(i == 0 || i == 2 || i == 4)
            {
                int temp = h2;
                h2 = d2;
                d2 = temp;
            }
            else if (i == 1)
            {
                int temp = d2;
                d2 = h2;
                h2 = w2;
                w2 = temp;
            }
            else if (i == 3)
            {
                int temp = w2;
                w2 = h2;
                h2 = d2;
                d2 = temp;
            }
        }
    }
}


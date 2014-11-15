using System;

class OddAndEvenProduct
{
    static void Main(string[] args)
    {
        string[] line = Console.ReadLine().Split(' ');

        int EvenProduct = 1;
        int OddProduct = 1;

        int temp;
        for (int i = 0; i < line.Length; i++)
        {
            if(i%2 != 0)
            {
                temp = Convert.ToInt32(line[i]);
                EvenProduct *= temp;
            }
            else if(i%2 == 0)
            {
                temp = Convert.ToInt32(line[i]);
                OddProduct *= temp;
            }
        }

        if(OddProduct == EvenProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = {0}",EvenProduct);
        }
        else
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = {0}",OddProduct);
            Console.WriteLine("even_product = {0}",EvenProduct);
        }
    }
}


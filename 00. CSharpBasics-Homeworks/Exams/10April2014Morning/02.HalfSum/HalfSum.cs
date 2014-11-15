using System;

class HalfSum
{
    static void Main(string[] args)
    {
        int temp = 0;
        int n = int.Parse(Console.ReadLine());

        // Calculate the sum of the first n numbers
        long FirstHalf = 0;
        for (int i = 0; i < n; i++)
        {
            temp = int.Parse(Console.ReadLine());
            FirstHalf += temp;
        }

        // Calculate the sum of the second n numbers
        long SecondHalf = 0;
        for (int i = 0; i < n; i++)
        {
            temp = int.Parse(Console.ReadLine());
            SecondHalf += temp;
        }

        // calculate difference
        if (FirstHalf == SecondHalf)
        {
            Console.WriteLine("Yes, sum={0}", FirstHalf);
        }
        else if (FirstHalf > SecondHalf)
        {
            Console.WriteLine("No, diff={0}", FirstHalf - SecondHalf);
        }
        else if (SecondHalf > FirstHalf)
        {
            Console.WriteLine("No, diff={0}", SecondHalf - FirstHalf);
        }
    }
}

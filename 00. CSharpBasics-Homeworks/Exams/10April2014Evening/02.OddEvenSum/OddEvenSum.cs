using System;

class OddEvenSum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); ;
        int SumEven = 0, SumOdd = 0;

        for (int i = 0; i < n; i++)
        {

            int temp = int.Parse(Console.ReadLine());
            SumOdd += temp;

            int T = int.Parse(Console.ReadLine());
            SumEven += T;
        }

        if (SumOdd == SumEven)
        {
            Console.WriteLine("Yes, sum=" + SumEven);
        }
        else
        {
            int Difirence = Math.Abs(SumEven - SumOdd);
            Console.WriteLine("No, diff=" + Difirence);
        }
    }
}

using System;

class PrimeNumberCheck
{
    static void Main(string[] args)
    {
        Console.Write("Enter Integer: ");
        int Num = int.Parse(Console.ReadLine());
        bool Prime = true;

        if( Num < 2)
        {
            Prime = false;
            Console.WriteLine(Prime);
        }
        else
        {
            for (int i = 2; i < Num/2; i++)
            {
                if (Num % i == 0)
                {
                    Prime = false;
                    break;
                }
            }
            Console.WriteLine(Prime);
        }
    }
}


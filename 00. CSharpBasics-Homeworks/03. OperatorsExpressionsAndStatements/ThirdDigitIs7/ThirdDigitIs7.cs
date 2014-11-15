
using System;

    class ThirdDigitIs7
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Integer: ");
            int Num = int.Parse(Console.ReadLine());

            if ((Num / 100) % 10 == 7)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }


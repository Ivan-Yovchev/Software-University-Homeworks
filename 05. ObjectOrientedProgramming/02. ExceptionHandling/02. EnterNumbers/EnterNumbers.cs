using System;

class EnterNumbers
{
    static void Main()
    {
        int start = 1;
        int end = 100;
        ReadNumber(start, end);
    }

    private static void ReadNumber(int start, int end)
    {

        int count = 10;

        while (count != 0)
        {
            try
            {
                Console.Write("Enter a" + (11 - count) + ": ");
                int number = int.Parse(Console.ReadLine());

                if (number < start || number > end)
                {
                    Console.Error.WriteLine("The value must be in the range [1...100]");
                }
                else
                {
                    Console.WriteLine("Okay !");
                    count--;
                }
            }
            catch (Exception)
            {
                Console.Error.WriteLine("The value must be a number");
            }
        }

    }

}
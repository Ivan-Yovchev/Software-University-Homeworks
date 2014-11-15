using System;

class CalculateGCD
{
    static void Main(string[] args)
    {
        Console.Write("Enter a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("GCM: " + GCD(a, b));
    }

    private static int GCD(int x, int y)
    {
        while (x != y)
        {
            if (x < 0)
            {
                x = -x;
            }
            else if (y < 0)
            {
                y = -y;
            }

            if(x > y)
            {
                x = x - y;
            }
            else
            {
                y = y - x;
            }
        }
        return x;
    }
}


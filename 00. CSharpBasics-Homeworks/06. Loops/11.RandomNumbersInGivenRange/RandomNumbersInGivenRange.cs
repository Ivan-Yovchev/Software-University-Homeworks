using System;

class RandomNumbersInGivenRange
{
    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter min value: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Enter max value: ");
        int max = int.Parse(Console.ReadLine());

        Random rand = new Random();

        for (int i = 0; i < n; i++)
        {
            int temp = rand.Next(min, (max + 1));
            Console.Write(temp + " ");
        }
        Console.WriteLine();
    }
}


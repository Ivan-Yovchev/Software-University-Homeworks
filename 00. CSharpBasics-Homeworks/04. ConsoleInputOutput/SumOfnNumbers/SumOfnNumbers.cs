using System;

class SumOfnNumbers
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        double num, sum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter a number: ");
            num = double.Parse(Console.ReadLine());
            sum += num;
        }

        Console.WriteLine("Sum: {0}",sum);
    }
}


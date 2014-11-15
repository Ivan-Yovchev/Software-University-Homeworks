using System;

class SumOf5Numbers
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        double sum = 0;
        Console.Write("Enter numbers: ");
        string[] numbers = Console.ReadLine().Split(' ');
        for (int i = 0; i < 5; i++)
        {
            sum += Convert.ToDouble(numbers[i]);
            
        }

        Console.WriteLine("Sum: {0}", sum);

    }
}


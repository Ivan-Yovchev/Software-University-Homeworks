using System;
class CalculateFactorielDividedByPowerSum
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter X: ");
        int x = int.Parse(Console.ReadLine());

        double Sum = 0;
        int factoriel = 1;
        int num = 1;
        double power = x;

        for (int i = 0; i < n; i++)
        {
            Sum += factoriel / power;

            factoriel = (num + 1) * factoriel;
            power *= x;
            num++;
        }
        

        Console.WriteLine("S = {0:F5}",(Sum + 1));
    }
}


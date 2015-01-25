using System;

class SquareRoot
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        try
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentException("The value must be a positive number");
            }

            Console.WriteLine("Square root of number: " + Math.Sqrt(number));

        }
        catch (Exception)
        {
            throw new FormatException("The value must be a number");
        }
        finally
        {
            Console.WriteLine("Good Bye!");
        }
    }
}
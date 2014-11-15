using System;

class IntDoubleString
{
    static void Main(string[] args)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 ---> int");
        Console.WriteLine("2 ---> double");
        Console.WriteLine("3 ---> string");

        int choise = int.Parse(Console.ReadLine());

        switch(choise)
        {
            case 1: Console.Write("Please enter an int: ");
                int intTemp = int.Parse(Console.ReadLine());
                Console.WriteLine(intTemp + 1); break;

            case 2: Console.Write("Please enter a double: ");
                double doubleTemp = double.Parse(Console.ReadLine());
                Console.WriteLine(doubleTemp + 1); break;

            case 3: Console.Write("Please enter a string: ");
                string stringTemp = Console.ReadLine();
                Console.WriteLine(stringTemp + "*"); break;
        }
    }
}


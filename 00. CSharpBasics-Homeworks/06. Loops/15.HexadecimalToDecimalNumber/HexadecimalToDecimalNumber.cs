using System;

class HexadecimalToDecimalNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter hexadecimal number: ");
        string Hex = Console.ReadLine();

        //calculate value
        long Number = 0;
        for (int i = 0; i < Hex.Length; i++)
        {
            Number += DecValue(Hex[i])*((long)Math.Pow(16,Hex.Length - 1 - i));
        }

        Console.WriteLine(Number);
    }

    private static long DecValue(char ch)
    {
        int value = 0;
        //hex values
        switch (ch)
        {
            case '1': value = 1; break;
            case '2': value = 2; break;
            case '3': value = 3; break;
            case '4': value = 4; break;
            case '5': value = 5; break;
            case '6': value = 6; break;
            case '7': value = 7; break;
            case '8': value = 8; break;
            case '9': value = 9; break;
            case 'A': value = 10; break;
            case 'B': value = 11; break;
            case 'C': value = 12; break;
            case 'D': value = 13; break;
            case 'E': value = 14; break;
            case 'F': value = 15; break;
        }

        return value;
    }
}


using System;

class DecimalToHexadecimalNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter decimal number: ");
        long number = long.Parse(Console.ReadLine());

        // get hex value
        string hex = "";
        while (number >= 16)
        {
            hex += GetHexValue(number % 16);
            number /= 16;
        }

        hex += GetHexValue(number);

        //reverse string
        string finalHex = "";
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            finalHex += hex[i];
        }

        Console.WriteLine(finalHex);
    }

    private static string GetHexValue(long p)
    {
        string value = "0";
        switch (p)
        {
            case 1: value = "1"; break;
            case 2: value = "2"; break;
            case 3: value = "3"; break;
            case 4: value = "4"; break;
            case 5: value = "5"; break;
            case 6: value = "6"; break;
            case 7: value = "7"; break;
            case 8: value = "8"; break;
            case 9: value = "9"; break;
            case 10: value = "A"; break;
            case 11: value = "B"; break;
            case 12: value = "C"; break;
            case 13: value = "D"; break;
            case 14: value = "E"; break;
            case 15: value = "F"; break;
        }
        return value;
    }
}


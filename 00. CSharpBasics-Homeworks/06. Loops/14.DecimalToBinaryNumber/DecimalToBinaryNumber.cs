using System;

class DecimalToBinaryNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter decimal number: ");
        long decimalNumber = long.Parse(Console.ReadLine());
        string binaryNumber = "";

        while (decimalNumber >= 2)
        {
            if (decimalNumber % 2 == 0)
            {
                binaryNumber += "0";
                decimalNumber /= 2;
            }
            else if (decimalNumber % 2 != 0)
            {
                binaryNumber += "1";
                decimalNumber /= 2;
            }
        }

        binaryNumber += decimalNumber;
        string finalNumber = "";

        for (int i = binaryNumber.Length - 1; i >= 0; i--)
        {
            if (binaryNumber[i] == '0')
            {
                finalNumber += "0";
            }
            else if (binaryNumber[i] == '1')
            {
                finalNumber += "1";
            }
        }

        Console.WriteLine(finalNumber);
    }
}


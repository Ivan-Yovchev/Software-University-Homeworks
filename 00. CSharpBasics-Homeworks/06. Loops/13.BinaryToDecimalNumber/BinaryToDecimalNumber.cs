using System;

class BinaryToDecimalNumber
{
    static void Main(string[] args)
    {
        Console.Write("Enter binary number: ");
        string binary = Console.ReadLine();

        //make sure the length of the string is dividable by 8
        int length = binary.Length;
        while (length % 8 != 0)
        {
            length++;
        }

        // now pad with zeros
        binary = binary.PadLeft(length, '0');

        //reverse string
        string finalNumber = "";

        for (int i = binary.Length - 1; i >= 0; i--)
        {
            if (binary[i] == '0')
            {
                finalNumber += "0";
            }
            else if (binary[i] == '1')
            {
                finalNumber += "1";
            }
        }

        //convert to decimal
        long Number = 0;
        for (int i = 0; i < finalNumber.Length; i++)
        {
            if (finalNumber[i] == '1')
            {
                Number += (long)Math.Pow(2, i);
            }
        }

        Console.WriteLine(Number);
    }
}


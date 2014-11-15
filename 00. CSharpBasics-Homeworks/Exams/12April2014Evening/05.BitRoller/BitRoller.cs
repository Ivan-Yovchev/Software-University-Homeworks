using System;

class BitRoller
{
    static void Main(string[] args)
    {
        uint number = uint.Parse(Console.ReadLine());
        int index = int.Parse(Console.ReadLine());
        int numberOfRolls = int.Parse(Console.ReadLine());

        string unmovedBit = "";
        string binary = Convert.ToString(number, 2).PadLeft(19, '0');
        index = 18 - index;
        char[] bits = binary.ToCharArray();
        binary = "";

        //remove unmoved bit to be added later
        for (int i = 0; i < bits.Length; i++)
        {
            if (i == index)
            {
                if (bits[i] == '0')
                {
                    unmovedBit = "0";
                }
                else
                {
                    unmovedBit = "1";
                }
                continue;
            }
            else
            {
                binary += bits[i];
            }
        }

        //roll bits
        bits = binary.ToCharArray();
        for (int i = 0; i < numberOfRolls; i++)
        {
            char lastBit = bits[bits.Length - 1];

            for (int j = bits.Length - 2; j >= 0; j--)
            {
                bits[j + 1] = bits[j];
            }

            bits[0] = lastBit;
        }

        //add unmoved bit
        binary = "";
        if (index != 0)
        {
            index -= 1;
        }
        for (int i = 0; i < bits.Length; i++)
        {
            if (i == index)
            {
                if (index == 0)
                {
                    binary += unmovedBit;
                    binary += bits[i];
                }
                else
                {
                    binary += bits[i];
                    binary += unmovedBit;
                }
            }
            else
            {
                binary += bits[i];
            }
        }

        long result = Convert.ToInt64(binary, 2);
        Console.WriteLine(result);
    }
}

using System;

class BitsKiller
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());

        string number = "";

        // get all numbers and turn them into binary numbers
        for (int i = 0; i < n; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            string num = Convert.ToString(temp, 2).PadLeft(8, '0');
            number += num;
        }

        // remove bits
        char[] RemoveBits = number.ToCharArray();
        for (int i = 1; i < RemoveBits.Length; i += step)
        {
            RemoveBits[i] = 'x';
        }

        // make a new string holding the new number
        string Bits = "";
        for (int i = 0; i < RemoveBits.Length; i++)
        {
            if (RemoveBits[i] == '1')
            {
                Bits += "1";
            }
            else if (RemoveBits[i] == '0')
            {
                Bits += "0";
            }
        }

        // make sure the new strings length is dividdable by 8 so it can be pad with zeros
        int length = Bits.Length;
        if (length % 8 != 0)
        {
            while (length % 8 != 0)
            {
                length++;
            }
        }
        // pad with zeros
        Bits = Bits.PadRight(length, '0');

        //output
        for (int i = 0; i < length; i += 8)
        {
            string temp = Bits.Substring(i, 8);
            int FinalNumber = Convert.ToInt32(temp, 2);
            Console.WriteLine(FinalNumber);
        }

    }
}

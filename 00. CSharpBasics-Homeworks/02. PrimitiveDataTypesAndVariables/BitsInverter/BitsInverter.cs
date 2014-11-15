using System;

class BitsInverter
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        string main = null;

        int Temp = 0;
        for (int i = 0; i < n; i++)
        {
            Temp = int.Parse(Console.ReadLine());
            string num = Convert.ToString(Temp, 2).PadLeft(8,'0');
            main += num;
        }

        //convert to char array
        char[] binary = main.ToCharArray();

        //exchange bits
        for (int i = 0; i < binary.Length; i+=step)
        {
            if(binary[i]=='0')
            {
                binary[i] = '1';
            }
            else if(binary[i]=='1')
            {
                binary[i] = '0';
            }
        }

        string NumbersBinary = new String(binary);

        for (int i = 0; i < NumbersBinary.Length; i = i + 8)
            {
                string number = NumbersBinary.Substring(i, 8);
                int Num = Convert.ToInt32(number,2);
                Console.WriteLine(Num);
            }

    }
}


using System;

class BitsUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        string main = null;

        for (int i = 0; i < n; i++)
        {
            int temp = int.Parse(Console.ReadLine());
            string sub = Convert.ToString(temp, 2).PadLeft(8, '0');
            main += sub;
        }

        char[] binary = main.ToCharArray();

        for (int i = 1; i < binary.Length; i+=step)
        {
            if(binary[i] == '0')
            {
                binary[i] = '1';
            }
        }

        string Number = new String(binary);

        for (int i = 0; i < Number.Length; i+=8)
        {
            string substring = Number.Substring(i, 8);
            int Num = Convert.ToInt32(substring, 2);
            Console.WriteLine(Num);
        }
    }
}


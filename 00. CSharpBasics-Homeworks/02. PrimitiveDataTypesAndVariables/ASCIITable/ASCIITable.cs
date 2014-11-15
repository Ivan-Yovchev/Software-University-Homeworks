using System;
class ASCIITable
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine(i + " --> " + (char)i);
        }
    }
}

